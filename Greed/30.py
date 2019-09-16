inputstring = str(input())
numbers = []

for c in inputstring:
    numbers.append(int(c))

if sum(numbers) % 3 == 0 and 0 in numbers:
    numbers.sort(reverse=True)
    print ''.join(map(str, numbers))
else:
    print -1