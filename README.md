# C#_anyagok

## Az elmélet teljesen váratlanul az elmélet nevű mappában található

## Nyilvantartas_01 projekt (versenyre átnézendő)
- egy dolgozói nyilvántartást tartalmaz , ahol az adatokat egy adatbázisban tároljuk, amit Entity Framework segítségével hozunk létre.
- az adatok kötve vannak a vezérlőkhöz
- a program végig kommentelve van
- két ablakot használunk, érdemes megnézni mindenféle verseny előtt

## Nyilt nevű projekt (FELTÉTLENÜL ÁTNÉZENDŐ versenyre)
- a 2025-ös emelt digitális kultúra érettségi adatbázis feladata C#-ban megoldva
- N:M-es kapcsolat a táblák között
- bemutatom, hogy jó deklarálással NEM KELL FLUENT API-t használni még ilyen esetben sem, mert az EF lekezeli automatikusan! (GYORS FEJLESZTÉS)
- és a kérdéseket is a lehető legegyszerűbben válaszolom meg (szerintem)
- [LINK a feladathoz](https://www.oktatas.hu/kozneveles/erettsegi/feladatsorok/emelt_szint_2025tavasz/emelt_11nap)

## Lottóhúzás nevű projekt (érdemes átfutni versenyre; WPF grafikus elemeinek létrehozása kódból!)
- a program nem rossz példa arra (bár régen csináltam), hogy hozunk létre programból vezérlőket, 10 percet megér az átnézése!
- egy ötöslottó húzást imitál valós adatokkal
- ezen a linken található az eddig húzott nyerőszámok összessége: [Nyerőszámok](https://bet.szerencsejatek.hu/cmsfiles/otos.csv)
- a letöltött fájlt kell változtatás nélkül a projekt mappájába másolni
- az öt szám kiválasztása után a program automatikusan kiírja, hogy az eddigi húzásokon hány darab 5-ös, 4-es stb. találatunk lett volna

## Unit tesztek
- a Unit teszteket tartalmazó projektek T betűvel kezdődnek majd
- az első ilyet elrontottam, így itt a tesztelendő osztályt tartalmazó projekt: **Unit_teszt_01**, a tesztprojekt: **SzamologepTeszt**
- a Kosar teszt egy könnyű és szerintem érthető bemutatása egy valós, egyszerű esetnek
- **fontos**: tesztelni nem azt kell, hogy mi az értéke a propertynek, hanem azt, hogy helyesen működik-e az üzleti logika!!!
- a Kosar tesztben már van komment az esetleges hibákról is!

## A Pizza6 projekt egy apró pizzarendelő alkalmazás JSON-be mentéssel - visszatöltéssel

## A Szokereso projekt egy "klasszikus" felfordítós játék
- csak az alapok
- angol, magyar mintafájl van a projekt mappájában, bármire cserélhető, lehet pontozást hozzáírni stb.

## A Szotanulo projekt két ablak használatáról szól
- és még valóban lehet vele szavakat is tanulni
- valamint az eseménykezelést is jobban meg lehet érteni

