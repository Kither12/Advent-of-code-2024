
def solve_1(a):
    a.append(0)
    arr = []
    for i in range(len(a)):
        if (i % 2 == 0):
            arr.extend([i // 2] * a[i])
        else:
            arr.extend([-1] * a[i])
    
    head = len(arr) - 1
    for i in range(len(arr)):
        
        if arr[i] == -1:
            while arr[head]==-1:
                head -= 1
            if i <= head :
                arr[i], arr[head] = arr[head], arr[i]
        if i > head:
            break
    return sum(i * arr[i]  for i in range(len(arr)) if arr[i] != -1)
                
def solve_2(a):
    a.append(0)
    arr = []
    for i in range(len(a)):
        if (i % 2 == 0):
            arr.append([i // 2, a[i]])
        else:
            arr.append([-1,  a[i]])
    head = len(arr) - 1
    while head >= 0:
        if arr[head][0] != -1:
            for i in range(head): # kinda brute force here
                if arr[i][0] == -1 and arr[i][1] >= arr[head][1]:
                    arr[i][1] -= arr[head][1]
                    
                    arr.insert(i, [arr[head][0], arr[head][1]])
                    head += 1 # since after insert, head will be shifted by 1
                    arr[head][0] = -1 # the old place will replace with -1
                    break
            
        head -= 1
        
    dp = []
    for i in range(len(arr)):
        
        dp.extend([arr[i][0]] * arr[i][1])
        
    return sum(i * dp[i] for i in range(len(dp)) if dp[i] != -1)

with open("sample.txt") as f:
    ar = f.read().splitlines()
    ar = list(map(int, ar[0]))
    print("Sample solution part 1 Day 9:", solve_1(ar[::]))
    print("Sample solution part 2 Day 9:", solve_2(ar))
    
    
with open("input.txt") as f:
    ar = f.read().splitlines()
    ar = list(map(int, ar[0]))
    
    print("Solution part 1 Day 9:", solve_1(ar[::]))
    print("Sample solution part 2 Day 9:", solve_2(ar))