
# Set
firstInput = raw_input().split(' ')
coinCount = int(firstInput[0])
predictValue = int(firstInput[1])
coins =[]
for coin in range(coinCount):
    coins.append(int(input()))

for coin in coins:
    if coin > predictValue:
        coins.remove(coin)

coins.reverse()
remainValue = predictValue
sumCount = 0;
for coin in coins:
    coinCount = remainValue // coin
    sumCount += coinCount
    remainValue = remainValue % coin

    if remainValue == 0:
        print(sumCount)
        break

