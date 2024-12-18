# for faster computation
from gmpy2 import mpz

def solve_1(ar):
    cnt = 0
    for q in ar:
        sum, a = q.split(': ')
        sum = int(sum)
        a = list(map(int, a.split()))
        n = len(a)
        for mask in range(1<<n):
            s = a[0]
            for i in range(1, n):
                if mask & (1<<i):
                    s += a[i]
                else:
                    s *= a[i]
            if s == sum:
                cnt += s
                break
        
    return cnt
        
        
def solve_2(ar):
    cnt = 0
    import concurrent.futures

    def process_q(q):
        S, a = q.split(': ')
        S = mpz(S)
        a = list(map(mpz, a.split()))
        n = len(a)
        len_a = [len(str(x)) for x in a]
        # to be honest, we could use branch and bound here
        # but i'm lazy to implement that shiet in Python (due to it's nature of recursion)
        for mask in range(3**n):
            s = a[0]
            
            for i in range(1, n):
                if mask % 3 == 0:
                    s += a[i]
                elif mask % 3 == 1:
                    s *= a[i]
                else:
                    s = s * mpz(10) ** (len_a[i]) + a[i]
                    
                if s > S:
                    break
                mask //= 3
                
            if s == S:
                return s
        return 0

    with concurrent.futures.ThreadPoolExecutor(100) as executor:
        results = list(executor.map(process_q, ar))
        cnt = sum(results)
    return cnt
    

with open("sample.txt") as f:
    ar = f.read().splitlines()
    print(f"Sample for part 1 Day 7: {solve_1(ar[::])}")
    print(f"Sample for part 2 Day 7: {solve_2(ar[::])}")
    
    
    
with open("input.txt") as f:
    ar = f.read().splitlines()
    print(f"Solution for part 1 Day 7: {solve_1(ar[::])}")
    print(f"Solution for part 2 Day 7: {solve_2(ar[::])}")
    
    