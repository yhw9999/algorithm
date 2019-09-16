count = raw_input()
# noinspection PyInterpreter
perTime = map(int,raw_input().split(' '))
perTime.sort()

result = 0

for index in range(len(perTime)):
    getTimes = perTime[:index+1]
    result += sum(getTimes)

print(result)