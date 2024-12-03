use std::fs;

use regex::Regex;


fn solve_1(s: &str) -> i128{
    let mut ans: i128 = 0;
    // With the help from AI to find this regex crate and how to use it
    let re = Regex::new(r"mul\((\d+),(\d+)\)").unwrap();
    for caps in re.captures_iter(s) {
        let num1: i128 = caps[1].parse().unwrap();
        let num2: i128 = caps[2].parse().unwrap();
        ans += num1 * num2;
    }
    ans 
}

fn main() {
    let text = fs::read_to_string("input.txt").unwrap();
    
    println!("Answer for Day 3 Part 1: {}", solve_1(&text));
}

