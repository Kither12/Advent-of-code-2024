use std::fs::read_to_string;
use std::ops::Div;

fn solve_1(s: &str) -> i32 {
    let mut ans = 0;
    let parts: Vec<&str> = s.split("\n\n").collect();
    let part1 = parts[0];
    let part2 = parts[1];
    let lines: Vec<&str> = part1.split('\n').collect();
    // Because we know that all of the number in range form 0-99, we will make 2D array of 100 x 100
    let mut grid: Vec<Vec<i32>> = vec![vec![0; 100]; 100];
    
    
    for line in lines {
        let parts: Vec<&str> = line.split('|').collect();
        let a: i32 = parts[0].parse().unwrap();
        let b: i32 = parts[1].parse().unwrap();
        grid[a as usize][b as usize] = 1;
        grid[b as usize][a as usize] = -1;
    }

    let lines = part2.split('\n').collect::<Vec<&str>>();
    for line in lines {
        let tmp = line.split(',').map(|x| x.parse::<i32>().unwrap()).collect::<Vec<i32>>();
        let mut can: bool = true;
        'bonk: for i in 0..tmp.len() {
            for j in i+1..tmp.len() {
                if grid[tmp[i] as usize][tmp[j] as usize] != 1 {
                    can = false;
                    break 'bonk;
                }
            }
        }
        if can {
            ans += tmp[tmp.len().div(2)];
        }
    }
    ans
}


fn solve_2(s: &str) -> i32 {
    let mut ans = 0;
    let parts: Vec<&str> = s.split("\n\n").collect();
    let part1 = parts[0];
    let part2 = parts[1];
    let lines: Vec<&str> = part1.split('\n').collect();
    // Because we know that all of the number in range form 0-99, we will make 2D array of 100 x 100
    let mut grid: Vec<Vec<i32>> = vec![vec![0; 100]; 100];
    
    
    for line in lines {
        let parts: Vec<&str> = line.split('|').collect();
        let a: i32 = parts[0].parse().unwrap();
        let b: i32 = parts[1].parse().unwrap();
        grid[a as usize][b as usize] = 1;
        grid[b as usize][a as usize] = -1;
    }

    let lines = part2.split('\n').collect::<Vec<&str>>();
    for line in lines {
        let mut tmp = line.split(',').map(|x| x.parse::<i32>().unwrap()).collect::<Vec<i32>>();
        let mut can: bool = true;
        for i in 0..tmp.len() {
            for j in i+1..tmp.len() {
                if grid[tmp[i] as usize][tmp[j] as usize] != 1 {
                    can = false;
                    tmp.swap(i, j);
                }
            }
        }
        if can == false {
            ans += tmp[tmp.len().div(2)];
        }
    }
    ans
}



fn main() {
    let content = read_to_string("input.txt").expect("lmao!");
    println!("Solution to Day 5 part 1: {}", solve_1(&content));
    println!("Solution to Day 5 part 2: {}", solve_2(&content));

}
