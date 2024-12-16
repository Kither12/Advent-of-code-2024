use std::fs::read_to_string;


const dx: [i32; 4] = [0, 1, 0, -1];
const dy: [i32; 4] = [-1, 0, 1, 0];

fn part1(a: Vec<&str>) -> i32 {
    let mut cnt = 0;
    let mut x = 0;
    let mut y = 0;
    'first: for i in 0..a.len() {
        for j in 0..a[0].len() {
            let c = a[i].chars().nth(j).unwrap();
            if c == '^' {
                x = i as i32;
                y = j as i32;
                break 'first;
            }
        }
        
    }

    let mut k = 0;
    loop {
        let (nx, ny) = (x + dx[k] , y + dy[k]);
        if (nx < 0 || nx >= a.len() as i32 || ny < 0 || ny >= a[0].len() as i32) {
            break;
        }
        if a[nx as usize].chars().nth(ny as usize).unwrap() == '#' {
            k = (k + 1) % 4;
        }
        else {
            a[x as usize][y as usize] = '#';
            x = nx;
            y = ny;
        }
    }
    
    for i in 0..a.len() {
        for j in 0..a[0].len() {
            let c = a[i].chars().nth(j).unwrap();
            if c == '#'{
                cnt += 1
            }

        }
    }
    cnt
}

fn main() {
    let lines = read_to_string("input.txt").unwrap();
    
    let grid = lines.split("\n").collect::<Vec<&str>>();
    println!("Answer for Day 6 part 1: {}", part1(grid));
    
}
