use std::fs;

fn solve_1(s: &str) -> i32 {
    let mut ans = 0;
    let lines = s.trim_end()
        .split("\n")
        .map(|x| x.split(" ")
            .map(|num| num.parse::<i32>().unwrap())
            .collect::<Vec<i32>>())
        .collect::<Vec<Vec<i32>>>();
    
    for x in lines {
        let mut tmp = x.clone();
        tmp.sort();
        let mut flag = false;
        if tmp == x {
            flag = true;
        }
        tmp.reverse();
        if tmp == x {
            flag = true;
        }
        if flag {
            for i in 0..x.len() - 1 {
                if (x[i] - x[i + 1]).abs() > 3 || (x[i] - x[i + 1]).abs() == 0 {
                    flag = false;
                }
            }
        }
        if flag {
            ans += 1;
        }
    }
    
    ans 
}

fn main() {
    let content = fs::read_to_string("day2.txt").expect("Unable to read file");
    
    println!("{}", solve_1(&content));
}
