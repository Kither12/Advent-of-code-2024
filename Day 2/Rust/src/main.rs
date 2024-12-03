use std::fs;

fn solve_1(s: &str) -> i32 {
    let mut ans = 0;
    let lines = s.trim_end()
        .split("\n")
        .map(|x| x.split(" ")
            .map(|num| num.parse::<i32>().unwrap())
            .collect::<Vec<i32>>())
        .collect::<Vec<Vec<i32>>>();
    
    'outter: for x in lines {
        // is_sorted is a function can only be use in version >= 1.82 of rustc
        if x.is_sorted_by_key(|x| -x) || x.is_sorted() {
            for i in 0..x.len() - 1 {
                if (1..=3).contains(&(x[i] - x[i + 1]).abs()) == false {
                    continue 'outter;
                }
            }
        } else {
            continue;
        }
        ans += 1;
        
    }    
    ans 
}


fn solve_2(s: &str) -> i32 {
    let mut ans = 0;
    let lines = s.trim_end()
        .split("\n")
        .map(|x| x.split(" ")
            .map(|num| num.parse::<i32>().unwrap())
            .collect::<Vec<i32>>())
        .collect::<Vec<Vec<i32>>>();

    fn check(a: &Vec<i32>) -> bool {
        if !(a.is_sorted_by_key(|x| -x) || a.is_sorted()) {
            return false;
        } 
        // windows acting as a sliding windows, it's returns all consecutives with given size.
        return a.windows(2) 
                .any(|x| (1..=3) .contains(&(x[0] - x[1]).abs()) == false) 
                == false
        
    }
    for x in lines {
        // is_sorted is a function can only be use in version >= 1.82 of rustc 
        if check(&x) == false {
            // println!("{:?}", x);

            for i in 0..x.len() {
                let mut tmp = x.clone();
                tmp.remove(i);
                // println!("{:?}", tmp);
                if check(&tmp) {
                    ans += 1;
            
                    break;
                }
            }
        } else {
            ans += 1;
        }
              
    }
    
    ans
}

fn main() {
    // Make sure that the input file are readable, don't share the input file please.
    let content = fs::read_to_string("day2.txt").expect("Unable to read file");
    
    println!("Answers to Day 1 Part 2 is: {}", solve_2(&content));
    println!("Answers to Day 1 Part 1 is: {}", solve_1(&content));
}
