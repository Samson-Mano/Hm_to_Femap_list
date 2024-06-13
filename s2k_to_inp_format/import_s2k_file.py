import re

def read_s2k_file(file_path):
    nodes = []
    beams = []
    sections = {}
    areas = []
    area_sections = {}

    joint_pattern = re.compile(r'Joint=(\S+)\s+CoordSys=GLOBAL\s+CoordType=Cartesian\s+XorR=([-+\d.eE]+)\s+Y=([-+\d.eE]+)\s+Z=([-+\d.eE]+)')
    beam_pattern = re.compile(r'Frame=(\d+)\s+JointI=(\d+)\s+JointJ=(\d+)\s+IsCurved=No\s+Length=[-+\d.eE]+\s+CentroidX=[-+\d.eE]+\s+CentroidY=[-+\d.eE]+\s+CentroidZ=[-+\d.eE]+\s+GUID=\S+')
    section_pattern = re.compile(r'Frame=(\d+)\s+SectionType=\S+\s+AutoSelect=\S+\s+AnalSect="([^"]+)"\s+DesignSect="([^"]+)"\s+MatProp=\S+')
    area_pattern = re.compile(r'Area=(\d+)\s+NumJoints=(\d+)\s+Joint1=(\S+)\s+Joint2=(\S+)\s+Joint3=(\S+)(?:\s+Joint4=(\S+))?')
    area_section_pattern = re.compile(r'Area=(\d+)\s+Section="([^"]+)"\s+MatProp=\S+')
    
    with open(file_path, 'r') as file:
        for line in file:
            joint_match = joint_pattern.search(line)
            if joint_match:
                node_id = joint_match.group(1)
                x_coord = float(joint_match.group(2))
                y_coord = float(joint_match.group(3))
                z_coord = float(joint_match.group(4))
                nodes.append((node_id, x_coord, y_coord, z_coord))
            
            beam_match = beam_pattern.search(line)
            if beam_match:
                frame_id = beam_match.group(1)
                joint_i = beam_match.group(2)
                joint_j = beam_match.group(3)
                beams.append((frame_id, joint_i, joint_j))
                
            section_match = section_pattern.search(line)
            if section_match:
                frame_id = section_match.group(1)
                anal_sect = section_match.group(2)
                design_sect = section_match.group(3)
                sections[frame_id] = (anal_sect, design_sect)

            area_match = area_pattern.search(line)
            if area_match:
                area_id = area_match.group(1)
                num_joints = int(area_match.group(2))
                joint1 = area_match.group(3)
                joint2 = area_match.group(4)
                joint3 = area_match.group(5)
                joint4 = area_match.group(6) if num_joints == 4 else None
                areas.append((area_id, num_joints, joint1, joint2, joint3, joint4))

            area_section_match = area_section_pattern.search(line)
            if area_section_match:
                area_id = area_section_match.group(1)
                section_name = area_section_match.group(2)
                area_sections[area_id] = section_name
    
    return nodes, beams, sections, areas, area_sections

def write_nastran_file(nodes, beams, sections, areas, area_sections, output_file_path):
    node_map = {node_id: i+1 for i, (node_id, _, _, _) in enumerate(nodes)}
    section_map = {section: i+1 for i, section in enumerate(set(section for _, section in sections.values()))}
    
    element_sections = {}
    for area_id, num_joints, joint1, joint2, joint3, joint4 in areas:
        section = area_sections.get(area_id, "Unknown")
        if section not in element_sections:
            element_sections[section] = []
        element_sections[section].append(area_id)

    with open(output_file_path, 'w') as file:
        file.write('$ Nodes in Nastran format\n')
        for i, (node_id, x, y, z) in enumerate(nodes, start=1):
            file.write(f'GRID,{i},,{x:.6f},{y:.6f},{z:.6f}\n')
        
        file.write('$ Beams in Nastran format\n')
        for frame_id, joint_i, joint_j in beams:
            node_i = node_map[joint_i]
            node_j = node_map[joint_j]
            section = sections.get(frame_id, ("Unknown", "Unknown"))
            pid = section_map.get(section[0], 1)
            file.write(f'CBAR,{frame_id},{pid},{node_i},{node_j}\n')
        
        file.write('$ Areas in Nastran format\n')
        for area_id, num_joints, joint1, joint2, joint3, joint4 in areas:
            node1 = node_map[joint1]
            node2 = node_map[joint2]
            node3 = node_map[joint3]
            section = area_sections.get(area_id, "Unknown")
            pid = section_map.get(section, 1)
            if num_joints == 3:
                file.write(f'CTRIA3,{area_id},{pid},{node1},{node2},{node3}\n')
            elif num_joints == 4:
                node4 = node_map[joint4]
                file.write(f'CQUAD4,{area_id},{pid},{node1},{node2},{node3},{node4}\n')

        file.write('$ Element Sets in Nastran format\n')
        set_id = 1
        for section, elements in element_sections.items():
            elements = sorted(elements)
            file.write(f'$ *set name = Section="{section}"\n')
            file.write(f'SET {set_id} =')
            for i, element in enumerate(elements):
                if i > 0 and i % 10 == 0:  # New line after every 10 elements for better readability
                    file.write('\n        ')
                file.write(f'{element},')
            file.write('\n')
            set_id += 1

def convert_s2k_to_nastran(input_file_path, output_file_path):
    nodes, beams, sections, areas, area_sections = read_s2k_file(input_file_path)
    write_nastran_file(nodes, beams, sections, areas, area_sections, output_file_path)




# Example usage
input_file_path = 'C:/Users/HFXMSZ/OneDrive - LR/Documents/Work/FEA main/ARC Caribe/FE Model/Test_conversion/arc_caribe_original.s2k'
output_file_path = 'C:/Users/HFXMSZ/OneDrive - LR/Documents/Work/FEA main/ARC Caribe/FE Model/Test_conversion/arc_caribe_original.dat'
convert_s2k_to_nastran(input_file_path, output_file_path)