
with open("input.txt") as f:
    lines = f.readlines()

id = lines.index("\n")
lines = [line.strip() for line in lines]
# print(lines)

def solve_1(lines, id):
    ans = 0
    for updates in lines[id + 1:]:
        nums = list(map(int, updates.split(',')))
        hash_map = {}
        for i, x in enumerate(nums):
            hash_map[x] = i
        flag = True
        for rules in lines[:id]:
            a, b = map(int, rules.split('|'))
            if a not in hash_map or b not in hash_map:
                continue
            if hash_map[a] > hash_map[b]:
                flag = False
                break
        if flag:
            ans += nums[len(nums) // 2]
    return ans


def fix(nums, cmp):
    for i in range(len(nums)):
        for j in range(i + 1, len(nums)):
            if cmp[nums[i]][nums[j]] == -1:
                nums[i], nums[j] = nums[j], nums[i]
    

def check(nums, cmp):
    for i in range(len(nums)):
        for j in range(i + 1, len(nums)):
            if cmp[nums[i]][nums[j]] == -1:
                return False
    return True

def solve_2(lines, id):
    edges = []
    n = 0
    cmp = [[0 for i in range(100)] for i in range(100)]
    for rules in lines[:id]:
        a, b = map(int, rules.split('|'))
        cmp[a][b] = 1
        cmp[b][a] = -1
        
    ans = 0
    for updates in lines[id + 1:]:
        nums = list(map(int, updates.split(',')))
        if check(nums, cmp) == True:
            continue 
        fix(nums, cmp)
        ans += nums[len(nums) // 2]
    return ans



print("Answer of Day 5 part 1:", solve_1(lines, id))
print("Answer of Day 5 part 2:", solve_2(lines, id))


