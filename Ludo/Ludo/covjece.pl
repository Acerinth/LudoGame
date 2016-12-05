:-dynamic ploca/4.
/*
:-dynamic crvena_kucica/2.
:-dynamic plava_kucica/2.
:-dynamic zelena_kucica/2.
:-dynamic zuta_kucica/2.
:-dynamic crveni_cilj/2.
:-dynamic plavi_cilj/2.
:-dynamic zeleni_cilj/2.
:-dynamic zuti_cilj/2.
*/
:-dynamic kocka/1.
:-dynamic igrac/4.
:-dynamic na_redu/1.
:-dynamic broj_igraca/1.
:-dynamic lista_igraca/1.

:-retractall(ploca(_,_,_,_)).
/*
:-retractall(crvena_kucica(_,_)).
:-retractall(zelena_kucica(_,_)).
:-retractall(plava_kucica(_,_)).
:-retractall(zuta_kucica(_,_)).
:-retractall(crveni_cilj(_,_)).
:-retractall(plavi_cilj(_,_)).
:-retractall(zeleni_cilj(_,_)).
:-retractall(zuti_cilj(_,_)).
*/
:-retractall(kocka(_)).
:-retractall(igrac(_,_,_,_)).
:-retractall(na_redu(_)).
:-retractall(broj_igraca(_)).
:-retractall(lista_igraca(_)).

ploca(1, start, red, 0). %start crveni
ploca(2, path, white, 0).
ploca(3, path, white, 0).
ploca(4, path, white, 0).
ploca(5, path, white, 0).
ploca(6, path, white, 0).
ploca(7, path, white, 0).
ploca(8, path, white, 0).
ploca(9, path, white, 0).
ploca(10, exit, blue, 0). %ulaz u plavu kucicu
ploca(11, start, blue, 0). %start plavi
ploca(12, path, white, 0).
ploca(13, path, white, 0).
ploca(14, path, white, 0).
ploca(15, path, white, 0).
ploca(16, path, white, 0).
ploca(17, path, white, 0).
ploca(18, path, white, 0).
ploca(19, path, white, 0).
ploca(20, exit, green, 0). %ulaz u zelenu kucicu
ploca(21, start, green, 0). %start zeleni
ploca(22, path, white, 0).
ploca(23, path, white, 0).
ploca(24, path, white, 0).
ploca(25, path, white, 0).
ploca(26, path, white, 0).
ploca(27, path, white, 0).
ploca(28, path, white, 0).
ploca(29, path, white, 0).
ploca(30, exit, yellow, 0). %ulaz u zutu kucicu
ploca(31, start, yellow, 0). %start zuti
ploca(32, path, white, 0).
ploca(33, path, white, 0).
ploca(34, path, white, 0).
ploca(35, path, white, 0).
ploca(36, path, white, 0).
ploca(37, path, white, 0).
ploca(38, path, white, 0).
ploca(39, path, white, 0).
ploca(40, exit, red, 0). %ulaz u crvenu kucicu


ploca(1, fhouse, red, 0). %ciljne kucice
ploca(2, fhouse, red, 0).
ploca(3, fhouse, red, 0).
ploca(4, fhouse, red, 0).

ploca(5, fhouse, blue, 0).
ploca(6, fhouse, blue, 0).
ploca(7, fhouse, blue, 0).
ploca(8, fhouse, blue, 0).

ploca(9, fhouse, green, 0).
ploca(10, fhouse, green, 0).
ploca(11, fhouse, green, 0).
ploca(12, fhouse, green, 0).

ploca(13, fhouse, yellow, 0).
ploca(14, fhouse, yellow, 0).
ploca(15, fhouse, yellow, 0).
ploca(16, fhouse, yellow, 0).


ploca(1, shouse, red, 0). %pocetne kucice
ploca(2, shouse, red, 0).
ploca(3, shouse, red, 0).
ploca(4, shouse, red, 0).

ploca(5, shouse, blue, 0).
ploca(6, shouse, blue, 0).
ploca(7, shouse, blue, 0).
ploca(8, shouse, blue, 0).

ploca(9, shouse, green, 0).
ploca(10, shouse, green, 0).
ploca(11, shouse, green, 0).
ploca(12, shouse, green, 0).

ploca(13, shouse, yellow, 0).
ploca(14, shouse, yellow, 0).
ploca(15, shouse, yellow, 0).
ploca(16, shouse, yellow, 0).




/*
crvena_kucica(1,0).
crvena_kucica(2,0).
crvena_kucica(3,0).
crvena_kucica(4,0).

plava_kucica(1,0).
plava_kucica(2,0).
plava_kucica(3,0).
plava_kucica(4,0).

zelena_kucica(1,0).
zelena_kucica(2,0).
zelena_kucica(3,0).
zelena_kucica(4,0).

zuta_kucica(1,0).
zuta_kucica(2,0).
zuta_kucica(3,0).
zuta_kucica(4,0).

crveni_cilj(1,0).
crveni_cilj(2,0).
crveni_cilj(3,0).
crveni_cilj(4,0).

plavi_cilj(1,0).
plavi_cilj(2,0).
plavi_cilj(3,0).
plavi_cilj(4,0).

zeleni_cilj(1,0).
zeleni_cilj(2,0).
zeleni_cilj(3,0).
zeleni_cilj(4,0).

zuti_cilj(1,0).
zuti_cilj(2,0).
zuti_cilj(3,0).
zuti_cilj(4,0).
*/


zeton(1,1).  %prvi arg => broj zetona, drugi arg => ID igraca
zeton(2,1).
zeton(3,1).
zeton(4,1).
zeton(5,2).
zeton(6,2).
zeton(7,2).
zeton(8,2).
zeton(9,3).
zeton(10,3).
zeton(11,3).
zeton(12,3).
zeton(13,4).
zeton(14,4).
zeton(15,4).
zeton(16,4).

igrac(1, nick1, red, 2).
igrac(2, nick2, blue, 2).
igrac(3, nick3, green, 2).
igrac(4, nick4, yellow, 2).

na_redu(0).
broj_igraca(0).
lista_igraca([]).

kocka(1).



baci_kocku() :- random_between(1,6,X), retract(kocka(_)), assert(kocka(X)).

spremi_igraca(N, Nick, Color, Type) :- retract(igrac(N,_,_,_)), assert(igrac(N,Nick,Color,Type)), broj_igraca(X), (Type\=2 -> Broj is X+1, retract(broj_igraca(_)), assert(broj_igraca(Broj)), lista_igraca(Lista), append(Lista,[N],Nova), retract(lista_igraca(_)), assert(lista_igraca(Nova)); true).

tko_pocinje() :- lista_igraca(Lista), random_member(X,Lista), retract(na_redu(_)), assert(na_redu(X)).

ima_zeton_na_ploci(Igrac) :- zeton(N, Igrac), ploca(_,path,_,N);
zeton(N,Igrac), ploca(_,start,_,N); zeton(N,Igrac), ploca(_,exit,_,N).

iduci_igrac(Igrac) :- lista_igraca(Lista), Iduci is Igrac+1, (Iduci>4 -> Novi is 1, true; Novi is Iduci, true), (not(member(Novi,Lista)) -> iduci_igrac(Novi); retract(na_redu(_)), assert(na_redu(Novi))).

postavi_zeton_u_kucicu(Zeton, Igrac) :- igrac(Igrac,_,Boja,_), retract(ploca(Zeton,shouse,Boja,_)), assert(ploca(Zeton,shouse,Boja,Zeton)).











