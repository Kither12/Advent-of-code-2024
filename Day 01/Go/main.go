package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}

func countFrequent(arr []int, value int) int {
	count := 0
	for _, num := range arr {
		if num == value {
			count++
		}
	}
	return count
}

func main() {
	var a, b []int
	file, err := os.Open("input.txt")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()
		parts := strings.Split(line, "   ")

		if len(parts) == 2 {
			first, _ := strconv.Atoi(parts[0])
			second, _ := strconv.Atoi(parts[1])

			a = append(a, first)
			b = append(b, second)
		}
	}

	if err := scanner.Err(); err != nil {
		fmt.Println("Error reading file:", err)
		return
	}

	sort.Ints(a)
	sort.Ints(b)

	var ans1 int
	for i := 0; i < len(a); i++ {
		tmp := abs(a[i] - b[i])
		ans1 += tmp
	}

	var ans2 int
	for _, numA := range a {
		countB := countFrequent(b, numA)
		ans2 += numA * countB
	}

	fmt.Println(ans1)
	fmt.Println(ans2)
}
