# n = length
# i = diffrence count
# a.length <= b.length

# result = find i

firstInput = raw_input().split(' ')
a = firstInput[0]
b = firstInput[1]

alength = len(a)
blength = len(b)
diffsize = blength - alength+1

besti = 50


def getdiff(stringa, stringb):
    diff = 0
    for i in range(len(stringa)):
        if stringa[i] != stringb[i]:
            diff += 1

    return diff


for index in range(diffsize):
    diffcount = getdiff(a, b[index:index+alength])

    if diffcount < besti:
        besti = diffcount


print besti