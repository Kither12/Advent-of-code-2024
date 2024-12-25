package main

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func main() {
	content, err := os.ReadFile("input.txt")
	if err != nil {
		fmt.Println("Error reading the file:", err)
		return
	}

	input := string(content)
	pattern := `mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)`

	re := regexp.MustCompile(pattern)
	matches := re.FindAllString(input, -1)

	ans := 0
	flag := true

	for _, match := range matches {
		if match == "do()" {
			flag = true
			continue
		}
		if match == "don't()" {
			flag = false
			continue
		}
		if flag {
			match = match[4 : len(match)-1]
			coords := strings.Split(match, ",")
			x, _ := strconv.Atoi(coords[0])
			y, _ := strconv.Atoi(coords[1])
			ans += x * y
		}
	}

	fmt.Println(ans)
}
