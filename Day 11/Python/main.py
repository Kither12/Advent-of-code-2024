import queue
from collections import defaultdict
q = queue.Queue()
# for x in :
#     q.put((x, 1))

ar = list(map(int, input().split()))
score = 0
for x in ar:
    q.put((x, 1))
    #              vv Change this to part 1 question number
    for _ in range(75):
        H = defaultdict(int)
        for j in range(q.qsize()):
            top, cnt = q.get()
            if top == 0:
                H[1] += cnt
            elif len(str(top)) % 2 == 0:
                top = str(top)
                first = int(top[:len(top)//2])
                second = int(top[len(top)//2:])
                H[first] += cnt
                H[second] += cnt
            else:
                H[top * 2024] += cnt
        for value, cnt in H.items():
            q.put((value, cnt))

    while q.qsize() > 0:
        score += q.get()[1]
print(score)