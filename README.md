# ALD semestral project

Daniel Kohout

### Programovací jazyk: C#

## GUI
Při spuštění se vygeneruje prázdná mapa, můžete buď krokovat algoritmus pomocí tlačítka Step, nebo můžete vygenerovat celou pomocí tlačítka Finish. Po vygenerování můžeme proces opakovat pomocí tlačítka Reset. Mapa je o velikosti 10x10;

## Algoritmus
Pro algoritmus jsem si vybral generování Prim's algoritmem. Tento algoritmus je především používán na generování bludišť, tudíž při generování mapy má vždy všechny dlaždice propojeny. 
### Funkčnost algoritmu
1. Vybere se náhodná startovací pozice a nastavíme ji jako defined
2. Všechny sousedy označíme jako "frontiers"
3. Náhodně vybereme další pozici z frontiers a nastavíme ji jako defined
4. U vybrané pozice se koukneme jestli má nějaké sousedy nastavené na defined a náhodně nastavíme k jednomu z nich cestu
5. Opakování od 2.bodu dokud existují ještě nejací "frontiers"

<p align="center">
  <img margin="30" width="340" height="300" src="https://user-images.githubusercontent.com/100781092/211205603-0ca3d75b-0450-425f-8602-33fe058f7641.png">
  <img margin="30" width="340" height="300" src="https://user-images.githubusercontent.com/100781092/211205613-4df22e79-db18-40f6-afb2-c82e88584185.png">
  <img margin="30" width="340" height="300" src="https://user-images.githubusercontent.com/100781092/211205591-51a18463-fc4e-4948-a777-dba470194cde.png">
  <img margin="30" width="340" height="300" src="https://user-images.githubusercontent.com/100781092/211205619-6177d4e2-dbbd-4268-b10d-a221412a4019.png">
</p>

## Předání mapy vytvořené algoritmem do GUI
1. Projdeme pole, kde máme u každé dlaždice cesty, uložené pomocí 4 boolean (left,top,right,bottom)
2. Vybereme "obrázek" dlaždice, kterou potrebujeme a dosadíme index "obrázku" do pole, které se předá GUI
(ps. "obrázek" je enum typ, propojený s <obrázek>.png)
