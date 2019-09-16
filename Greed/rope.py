ropecount = int(input())

ropes = []

for m in range(ropecount):
    ropes.append(int(input()))

ropes.sort()
ropes.reverse()

bestweight = ropes[0]

ropecount = 1

for rope in ropes:

    currentmaxweight = rope * ropecount

    if currentmaxweight >= bestweight:
        bestweight = currentmaxweight

    ropecount += 1


print bestweight
