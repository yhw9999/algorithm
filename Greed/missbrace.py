# backjun 1541
inputformula = raw_input()

splitedminus = inputformula.split('-')

minustargets = []
for plusformula in splitedminus:
    splitedplus = plusformula.split('+')
    if len(splitedplus) > 1:
        plusresult = int(splitedplus.pop(0))
        for plustarget in splitedplus:
            plusresult += int(plustarget)
        minustargets.append(plusresult)
    else:
        minustargets.append(int(plusformula))

result = minustargets.pop(0)

for target in minustargets:
    result -= target

print result
