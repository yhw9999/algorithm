payamount = int(raw_input())
predictValue = 1000-payamount
coins = [500, 100, 50, 10, 5, 1]

for coin in coins:
    if coin > predictValue:
        coins.remove(coin)

remainValue = predictValue
sumCount = 0
for coin in coins:
    coinCount = remainValue // coin
    sumCount += coinCount
    remainValue = remainValue % coin

    if remainValue == 0:
        print(sumCount)
        break