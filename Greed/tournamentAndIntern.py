# n = woman
# m = man
# k = intern

firstInput = raw_input().split(' ')
n = int(firstInput[0])
m = int(firstInput[1])
k = int(firstInput[2])

while k > 0:
    if n > m*2:
        n -= 1
    else:
        m -= 1

    k -= 1

if n > m*2:
    print m
else:
    print n // 2
