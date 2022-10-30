flats = 0
houses = []
chose = None
target = None
dimension = None
finalPrice = None

print("StanBud")
menu = """1 - dodaj mieszkania
2 - przejrzyj mieszkania
3 - szukaj konkretnego mieszkania
0 - wyjdź"""

while chose != "0":
    print(menu)
    print("Wybierz działanie")
    chose = input("Chcę: ")

    if chose == "1":
        flats = int(input("Ile bloków zostało wybudowanych? "))
        for i in range(flats):
            print("ile wolnych mieszkań jest w bloku nr", (i + 1), "? ")
            numberOfHouses = int(input("jest "))
            print("jaka jest szerokość mieszkań w bloku nr", (i + 1), "? ")
            widith = int(input("jest "))
            print("jaka jest długość mieszkań w bloku numer", (i + 1), "? ")
            lengtht = int(input("jest "))
            print("ile kosztuje metr kwadratowy w bloku numer", (i + 1), "?")
            price = int(input("kosztuje "))
            newHouse = [numberOfHouses, widith, lengtht, price]
            houses.append(newHouse)
            print("dodano blok numer".upper(), (i +1))
        print("Dodano mieszkania do bazy")

    elif chose == "2":
        if flats == 0:
            print("Baza mieszkań jest pusta")
        else:
            for i in range(len(houses)):
                print("W bloku numer", (i + 1), "jest", (houses[i][0]), "wolnych mieszkań o wymiarach", (houses[i][1]), "na", (houses[i][2]), "metra, w cenie", (houses[i][3]), "za metr kwadratowy.")
            print("\n")

    elif chose == "3":
        if (len(houses)) == 0:
            print("Baza mieszkań jest pusta")
        else:
            
            print("1 - po metrażu\n2 - po cenie\n0 - wróć")
            while target != "0":
                print("Jak chcesz szukać mieszkańia?")
                print("1 - po metrażu\n2 - po cenie\n0 - wróć")
                target = input("wybieram: ")
                if target == "1":
                    dimension = int(input("Ile metrów kwadratowych ma mieć te mieszkanie? "))
                    if (len(houses)) == 0:
                        print("Baza mieszkań jest pusta")
                    else: 
                        for i in range(len(houses)):
                            if ((houses[i][1]) * (houses[i][2])) == dimension:
                                print("W bloku numer", (i + 1), "są mieszkania o tym wymiarze")S
                            print("Koniec szukania wg metrażu")
                            input()
                elif target == "2":
                    finalPrice = int(input("Ile ma kosztować metr kwadratowy? "))
                    if (len(houses)) == 0:
                        print("Baza mieszkań jest pusta")
                    else:
                        for i in range(len(houses)):
                            if (houses[i][3]) == finalPrice:
                                print("W bloku numer", (i + 1), "są mieszkania w tej cenie za metr kwadratowy")
                            else:
                                continue
                            print("Koniec szukania wg ceny")
                            input()

    elif chose == "0":
        print("Dowidzenia")
        input()
                
        
