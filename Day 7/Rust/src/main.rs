use std::fs::File;
use std::io::{self, BufRead};
use std::sync::{Arc, Mutex};
use std::thread;



fn solve_1() {
    let file = File::open("input.txt").unwrap();
    let reader = io::BufReader::new(file);

    let sum = Arc::new(Mutex::new(0));
    // reader.lines().map(|line| )
    let handles: Vec<_> = reader.lines().map(|line| {
        let sum = Arc::clone(&sum);
        thread::spawn(move || {
            let line = line.unwrap();
            let l = line.split(": ").collect::<Vec<&str>>();
            let arr = l[1].split_whitespace().map(|x| x.parse::<i64>().unwrap()).collect::<Vec<i64>>();
            let total = l[0].parse::<i64>().unwrap();
            
            for mask in 0..(1<<arr.len()) {
                let mut s = arr[0];
                for i in 1..arr.len() {
                    if (mask >> (i - 1)) & 1 == 0 {
                        s += arr[i];
                    }  else {
                        s *= arr[i]
                    }
                }
                if s == total {
                    let mut sum = sum.lock().unwrap();
                    *sum += total;
                    break;
                }
            }
            
        })
    }).collect();

    for handle in handles {
        handle.join().unwrap();
    }
    println!("The sum is: {}", *sum.lock().unwrap());
}

fn main() -> io::Result<()> {
    
    solve_1();
    Ok(())
}
