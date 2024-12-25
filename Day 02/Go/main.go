package main

import (
	"fmt"
	"math"
	"os"
	"strconv"
	"strings"
)

func check(a []int) bool {
	if !(isDesc(a) || isAsc(a)) {
		return false
	}

	for i := 0; i < len(a)-1; i++ {
		if math.Abs(float64(a[i]-a[i+1])) < 1 || math.Abs(float64(a[i]-a[i+1])) > 3 {
			return false
		}
	}

	return true
}

func isDesc(list []int) bool {
	for i := 0; i < len(list)-1; i++ {
		if list[i] < list[i+1] {
			return false
		}
	}
	return true
}

func isAsc(list []int) bool {
	for i := 0; i < len(list)-1; i++ {
		if list[i] > list[i+1] {
			return false
		}
	}
	return true
}

func solve1(input string) int {
	ans := 0

	lines := strings.TrimSpace(input)
	lineArray := strings.Split(lines, "\n")

	for _, line := range lineArray {
		var x []int
		for _, val := range strings.Split(line, " ") {
			num, _ := strconv.Atoi(val)
			x = append(x, num)
		}

		if isDesc(x) || isAsc(x) {
			valid := true
			for i := 0; i < len(x)-1; i++ {
				if math.Abs(float64(x[i]-x[i+1])) < 1 || math.Abs(float64(x[i]-x[i+1])) > 3 {
					valid = false
					break
				}
			}
			if valid {
				ans++
			}
		}
	}

	return ans
}

func solve2(input string) int {
	ans := 0

	lines := strings.TrimSpace(input)
	lineArray := strings.Split(lines, "\n")

	for _, line := range lineArray {
		var x []int
		for _, val := range strings.Split(line, " ") {
			num, _ := strconv.Atoi(val)
			x = append(x, num)
		}

		if !check(x) {
			for i := 0; i < len(x); i++ {
				tmp := append([]int(nil), x[:i]...)
				tmp = append(tmp, x[i+1:]...)

				if check(tmp) {
					ans++
					break
				}
			}
		} else {
			ans++
		}
	}

	return ans
}

func main() {
	content, err := os.ReadFile("input.txt")
	if err != nil {
		fmt.Println("Error reading file:", err)
		return
	}

	fmt.Printf("Part 1: %d\n", solve1(string(content)))
	fmt.Printf("Part 2: %d\n", solve2(string(content)))
}
