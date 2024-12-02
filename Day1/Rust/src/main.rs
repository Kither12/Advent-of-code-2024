use std::fs;

fn solve_1(s: &str) -> i32 {
    let mut a: Vec<i32> = Vec::new();
    let mut b: Vec<i32> = Vec::new();
    s.split("\n").for_each(|line| {
        let tmp: Vec<&str> = line.split("   ").collect();
        // println!("{:?}", tmp); // for debugging
        a.push(tmp[0].parse::<i32>().unwrap());
        b.push(tmp[1].parse::<i32>().unwrap());
    });
    a.sort();
    b.sort();
    let mut sum = 0;
    for i in 0..a.len() {
        sum += (a[i] - b[i]).abs();
    }

    sum
}


fn solve_2(s: &str) -> i32 {
    let mut a: Vec<i32> = Vec::new();
    let mut b: Vec<i32> = Vec::new();
    s.split("\n").for_each(|line| {
        let tmp: Vec<&str> = line.split("   ").collect();
        // println!("{:?}", tmp); // for debugging
        a.push(tmp[0].parse::<i32>().unwrap());
        b.push(tmp[1].parse::<i32>().unwrap());
    });
    let mut ans = 0;
    for num_a in a {
        let count_b = b.iter().filter(|&x| x == num_a).count();
        ans += num_a * count_b as i32;
    }
    ans
}


fn main() {
    // Part 1
    let s = fs::read_to_string("input.txt").expect("Make sure that the input file are exists and readable");
    println!("Solve for first question: {}", solve_1(&s));
    println!("Solve for second question: {}", solve_2(&s));
}
