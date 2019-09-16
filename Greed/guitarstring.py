# backjun 1049 guitarstring
# n = cut count
# m = brand count
# first = package amount
# sencond = piece amount

cutandbrand = raw_input().split(' ')
cutcount = int(cutandbrand[0])
packagecount = cutcount // 6
piececount = cutcount % 6
brandcount = int(cutandbrand[1])

bestpackage = 1000 * packagecount
bestpiece = 1000 * piececount
totalprice = 1000 * cutcount

for i in range(brandcount):
    packageandpice = raw_input().split(' ')
    package = int(packageandpice[0])
    piece = int(packageandpice[1])
    packageamount = package * packagecount
    pieceamount = piece * piececount

    # all package

    multiplecount = packagecount if piececount == 0 else (packagecount + 1)
    temptotalprice = package * multiplecount
    if temptotalprice < totalprice:
        totalprice = temptotalprice

    # all piece
    temptotalprice = piece * (packagecount * 6 + piececount)
    if temptotalprice < totalprice:
        totalprice = temptotalprice
    # package and piece
    if bestpackage > packageamount:
        bestpackage = packageamount
    if bestpiece > pieceamount:
        bestpiece = pieceamount

if totalprice < bestpackage + bestpiece:
    print totalprice
else:
    print bestpackage + bestpiece