# t = test cast count
# n = volunteer count
# doc point, interview point

# output person count per 't'

t = int(input())
totalscores = []
scoreresult = []

for i in range(t):
    volunteercount = int(input())

    testscores = []
    for j in range(volunteercount):
        scoreinput = raw_input().split(' ')
        doc = int(scoreinput[0])
        interview = int(scoreinput[1])

        testscores.append((doc, interview))

    testscores.sort(key=lambda x: x[0])
    totalscores.append(testscores)


for checkscores in totalscores:
    successcount = 0
    index = 0
    for checktarget in checkscores:
        last = len(checkscores)
        doc, interview = checktarget
        index += 1

        if doc == 1 or interview == 1:
            successcount += 1
            continue
        elif doc == last or interview == last:
            continue

        uppertargets = checkscores[:index]

        if any(x for x in uppertargets if interview < x[1]):
            successcount += 1

    scoreresult.append(successcount)

for i in scoreresult:
    print i
