use std::fs;


fn solve_1(s: &str) -> i32 {
    let mut count = 0;
    // Use copilot to quicky generate the directions
    let directions = [
        (0, 1),  // right
        (1, 0),  // down
        (0, -1), // left
        (-1, 0), // up
        (1, 1),  // down-right
        (1, -1), // down-left
        (-1, 1), // up-right
        (-1, -1) // up-left
    ];

    let grid: Vec<Vec<char>> = s.lines().map(|line| line.chars().collect()).collect();
    let rows = grid.len();
    let cols = grid[0].len();
    let target = "XMAS".chars().collect::<Vec<_>>();

    for i in 0..rows {
        for j in 0..cols {
            for &(dx, dy) in &directions {
                let mut k = 0;
                let mut x = i as isize;
                let mut y = j as isize;
                while k < target.len() && x >= 0 && x < rows as isize && y >= 0 && y < cols as isize && grid[x as usize][y as usize] == target[k] {
                    k += 1;
                    x += dx;
                    y += dy;
                }
                if k == target.len() {
                    count += 1;
                }
            }
        }
    }
    count
}

fn solve_2(s: &str)  -> i32{
    let mut count = 0;

    let grid: Vec<Vec<char>> = s.lines().map(|line| line.chars().collect()).collect();
    let rows = grid.len();
    let cols = grid[0].len();

    fn is_valid_pattern(grid: &Vec<Vec<char>>, i: isize, j: isize, rows: usize, cols: usize) -> bool {
        if grid[i as usize][j as usize] != 'A' {
            return false;
        }

        let corners: [(isize, isize); 4] = [
            (i  - 1, j  - 1), 
            (i  - 1, j  + 1), 
            (i  + 1, j  - 1), 
            (i  + 1, j  + 1)  
        ];
        
        let mut m_arr: Vec<(isize, isize)> = vec![];
        let mut s_cnt = 0;

        for (x, y) in corners {
            if x >= 0 && x < rows as isize && y >= 0 && y < cols as isize {
                if grid[x as usize][y as usize] == 'M' {
                    m_arr.push((x, y));
                } else if grid[x as usize][y as usize] == 'S' {
                    s_cnt += 1;
                } else {
                    return false;
                }
            }
        }

        if (m_arr.len() != 2) || (s_cnt != 2) {
            return false;
        } 

        (m_arr[0].1 == m_arr[1].1) || (m_arr[0].0== m_arr[1].0)
    }

    for i in 0..rows {
        for j in 0..cols {
            if is_valid_pattern(&grid, i as isize, j as isize, rows, cols) {
                count += 1;
            }
        }
    }
    count
}
fn main() {
    let text = fs::read_to_string("input.txt").expect("Error reading file");
    println!("Answer for Day 4 part 1: {}", solve_1(&text));
    println!("Answer for Day 4 part 2: {}", solve_2(&text));
}
