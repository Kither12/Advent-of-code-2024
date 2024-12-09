use std::fs::read_to_string;


fn solve_1(s: &str) -> i32 {
    let mut ans = 0;
    let parts: Vec<&str> = s.split("\n\n").collect();
    let part1 = parts[0];
    let part2 = parts[1];
    let lines: Vec<&str> = part1.split('\n').collect();
    let mut edges: Vec<(i32, i32)> = vec![];
    for line in lines {
        let parts: Vec<&str> = line.split('|').collect();
        let a: i32 = parts[0].parse().unwrap();
        let b: i32 = parts[1].parse().unwrap();
        edges.push((a, b));
    }

    // IDK whether we should look for a loop in this kind of update <(")
    for (a, b) in &edges {
        if edges.contains(&(*b, *a)) {
            panic!("lmao");
        }
    }
    
    ans
}
fn main() {
    let content = read_to_string("input.txt").expect("lmao!");
    println!("Solution to Day 5 part 1: {}", solve_1(&content));
}
