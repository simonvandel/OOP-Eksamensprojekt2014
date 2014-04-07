OOP-Eksamensprojekt2014
=======================

AAU - OOP Eksamensprojekt 2014

Antagelser:
  - Oprettelser:
    - Handlende skal have et ID. Saldo må gerne komme senere.
    - Søgefunktioner, udover de angivede, kan konstrueres ved hjælp af den generiske Søg metode.
    - Ved søgefunktion 2 forståes det, at toiletfaciliteter altid ønskes.

Overvejelser:


Problem: Hvordan skal Højde, bredde, længde defineres for at undgå koderedundans?

Muligheder: Interfaces eller subklasse eller inkluder i køretøj.

Inkluder i køretøj:

For:

- Generel løsning - alle fysiske objekter har dimensioner. Passer til flere problemer (nye behov).
- 

Imod:

- Opgaven forventer ikke at f.eks. personbil har dimensioner.



Subklasse (Superklasse (arver fra køretøj) der har Lastbil og Bus som børn):

For:
- Vi viser at vi kan udvide klassehierakiet udover Køretøj-subklasse
- Skal kun definere dimensioner ét sted.
- min-max motorstørrelse kan defineres et sted, for at genbruge værdierne.



Interface: IKøretøjDimensioner


Antagelser:

Registreringsnummer: Vi antager at de to bogstaver i registreringsnummer er de første 2 tegn.


Årstal: 
efter 2010 forståes som: efter 1. Januar 2010 kl 00.00.
