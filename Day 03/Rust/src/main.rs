use std::fs;

// Remember to add the regex crate to Cargo.toml
// or just use cargo add regex
// Link info about regex crate: https://crates.io/crates/regex
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

fn solve_2(s: &str) -> i128{
    // Padding the first "do()" to make the code works
    let s = "do()".to_string() + s;
    let mut ans: i128 = 0;
    let re = Regex::new(r"mul\((\d+),(\d+)\)").unwrap();
    let arr = s.split("don\'t()").collect::<Vec<&str>>();
    for tmp in arr {
        let parts: Vec<&str> = tmp.split("do()").skip(1).collect();
        for part in parts {
            for caps in re.captures_iter(part) {
                let num1: i128 = caps[1].parse().unwrap();
                let num2: i128 = caps[2].parse().unwrap();
                ans += num1 * num2;
            }
        }

    }
    ans 
}


fn main() {
    let text = fs::read_to_string("input.txt").unwrap();
    
    println!("Answer for Day 3 Part 1: {}", solve_1(&text));
    println!("Answer for Day 3 Part 2: {}", solve_2(&text));

}

