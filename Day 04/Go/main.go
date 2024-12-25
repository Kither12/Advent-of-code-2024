package main

import (
	"fmt"
	"os"
	"strings"
)

func isValidPattern(grid [][]rune, i, j, rows, cols int) bool {
	if grid[i][j] != 'A' {
		return false
	}

	corners := [4][2]int{
		{i - 1, j - 1},
		{i - 1, j + 1},
		{i + 1, j - 1},
		{i + 1, j + 1},
	}

	var mArr [][2]int
	sCount := 0

	for _, corner := range corners {
		x, y := corner[0], corner[1]

		if x >= 0 && x < rows && y >= 0 && y < cols {
			switch grid[x][y] {
			case 'M':
				mArr = append(mArr, [2]int{x, y})
			case 'S':
				sCount++
			default:
				return false
			}
		}
	}

	return len(mArr) == 2 && sCount == 2 && (mArr[0][0] == mArr[1][0] || mArr[0][1] == mArr[1][1])
}

func solve1(s string) int {
	count := 0

	directions := [8][2]int{
		{0, 1}, {1, 0}, {0, -1}, {-1, 0},
		{1, 1}, {1, -1}, {-1, 1}, {-1, -1},
	}

	lines := strings.Split(s, "\n")
	grid := make([][]rune, len(lines))
	for i, line := range lines {
		grid[i] = []rune(line)
	}

	rows := len(grid)
	cols := len(grid[0])
	target := []rune("XMAS")

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			for _, dir := range directions {
				k := 0
				x, y := i, j

				for k < len(target) && x >= 0 && x < rows && y >= 0 && y < cols && grid[x][y] == target[k] {
					k++
					x += dir[0]
					y += dir[1]
				}

				if k == len(target) {
					count++
				}
			}
		}
	}

	return count
}

func solve2(s string) int {
	count := 0

	lines := strings.Split(s, "\n")
	grid := make([][]rune, len(lines))
	for i, line := range lines {
		grid[i] = []rune(line)
	}

	rows := len(grid)
	cols := len(grid[0])

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			if isValidPattern(grid, i, j, rows, cols) {
				count++
			}
		}
	}

	return count
}

func main() {
	file, err := os.ReadFile("input.txt")
	if err != nil {
		fmt.Println("Error reading file:", err)
		return
	}

	s := string(file)

	fmt.Printf("Part 1: %d\n", solve1(s))
	fmt.Printf("Part 2: %d\n", solve2(s))
}
