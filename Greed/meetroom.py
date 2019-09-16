import copy


def getbestcount(meetings, meeting, currentdepth):
    othermeetings = copy.deepcopy(meetings)
    othermeetings.remove(meeting)
    nextmeetings = getnextmeetings(othermeetings, meeting)

    global bestcount
    if len(nextmeetings) > 0:
        for nextmeeting in nextmeetings:
            getbestcount(nextmeetings, nextmeeting, currentdepth + 1)
    else:
        if bestcount < currentdepth:
            bestcount = currentdepth


def getnextmeetings(meetings, timeinfo):
    stime, etime = timeinfo
    try:
        filtered = filter(lambda x: int(x[0]) >= int(etime), meetings)
        return filtered
    except:
        return []


meetingCount = int(input())

originmeetings = []

for m in range(meetingCount):
    startAndEnd = raw_input().split(' ')
    startTime = startAndEnd[0]
    endTime = startAndEnd[1]
    timePack = (startTime, endTime)

    originmeetings.append(timePack)

bestcount = 1
for m in originmeetings:
    getbestcount(originmeetings, m, 1)

print(bestcount)