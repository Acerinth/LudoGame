:-dynamic ploca/4.
:-dynamic kocka/1.
:-dynamic igrac/4.
:-dynamic na_redu/1.
:-dynamic broj_igraca/1.
:-dynamic lista_igraca/1.
:-dynamic zeton/1.
:-dynamic novo_polje/1.

:-retractall(ploca(_,_,_,_)).
:-retractall(kocka(_)).
:-retractall(igrac(_,_,_,_)).
:-retractall(na_redu(_)).
:-retractall(broj_igraca(_)).
:-retractall(lista_igraca(_)).
:-retractall(zeton(_)).
:-retractall(novo_polje(_)).

% ----------------------------- BAZA ZNANJA ----------------------------
% definicije polja ploce
% (polja: start = pocetno, path = put, exit = izlaz)

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

% definicije polja ciljnih kucica (fhouse = final house)
%     -crvena kucica
ploca(41, fhouse, red, 0).
ploca(42, fhouse, red, 0).
ploca(43, fhouse, red, 0).
ploca(44, fhouse, red, 0).

%     -plava kucica
ploca(41, fhouse, blue, 0).
ploca(42, fhouse, blue, 0).
ploca(43, fhouse, blue, 0).
ploca(44, fhouse, blue, 0).

%     -zelena kucica
ploca(41, fhouse, green, 0).
ploca(42, fhouse, green, 0).
ploca(43, fhouse, green, 0).
ploca(44, fhouse, green, 0).

%      -zuta kucica
ploca(41, fhouse, yellow, 0).
ploca(42, fhouse, yellow, 0).
ploca(43, fhouse, yellow, 0).
ploca(44, fhouse, yellow, 0).

% definicija pocetnih kucica (shouse = start house)
%     -crvena kucica
ploca(1, shouse, red, 0).
ploca(2, shouse, red, 0).
ploca(3, shouse, red, 0).
ploca(4, shouse, red, 0).

%     -plava kucica
ploca(5, shouse, blue, 0).
ploca(6, shouse, blue, 0).
ploca(7, shouse, blue, 0).
ploca(8, shouse, blue, 0).

%     -zelena kucica
ploca(9, shouse, green, 0).
ploca(10, shouse, green, 0).
ploca(11, shouse, green, 0).
ploca(12, shouse, green, 0).

%     -zuta kucica
ploca(13, shouse, yellow, 0).
ploca(14, shouse, yellow, 0).
ploca(15, shouse, yellow, 0).
ploca(16, shouse, yellow, 0).


% definicija zetona
%  (prvi arg => ID zetona, drugi arg => ID igraca)

zeton(1,1).
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

% definicija igraca
%  (argumenti: 1-ID igraca, 2-ime igraca, 3-boja, 4-vrsta igraca
%  (0: human, 1: cpu, 2: ne igra)

igrac(1, nick1, red, 2).
igrac(2, nick2, blue, 2).
igrac(3, nick3, green, 2).
igrac(4, nick4, yellow, 2).


% globalne varijable

na_redu(0). % sprema ID igraca koji je trenutno na redu
broj_igraca(0). % sprema ukupan broj igraca
lista_igraca([]). % sprema listu igraca koji igraju
zeton(0). % sprema ID zetona, koristi se po potrebi
novo_polje(0). % sprema ID polja, koristi se po potrebi

kocka(1). % sprema vrijednost kocke dobivene simuliranim bacanjem




% ------------------------------ PRAVILA --------------------------

% simulira bacanje kocke. Uzima sluèajni broj izmeğu 1 i 6, te
% ga sprema u varijablu kocka(X).
baci_kocku() :- random_between(1,6,X), retract(kocka(_)), assert(kocka(X)).

% najprije sprema danog igraca u bazu znanja. Uèitava broj igraèa u
% varijablu X, provjerava dali je tip netom unesenog igraèa "ne igra".
% Ako nije, poveæava varijablu X i sprema je u broj_igraca, te novo
% dodanog igraèa dodaje u listu_igraca. Ako je tip "ne igra", samo
% završava s true.
spremi_igraca(N, Nick, Color, Type) :-
	retract(igrac(N,_,_,_)), assert(igrac(N,Nick,Color,Type)),
	broj_igraca(X), (Type\=2 -> Broj is X+1,
			 retract(broj_igraca(_)), assert(broj_igraca(Broj)),
			 lista_igraca(Lista), append(Lista,[N],Nova),
			 retract(lista_igraca(_)), assert(lista_igraca(Nova)); true).

% odreğuje koji igrac zapoèinje igru. Uèitava listu, odreğuje sluèajni
% element iz liste i sprema ga u globalnu varijablu na_redu(X).
tko_pocinje() :- lista_igraca(Lista), random_member(X,Lista),
	retract(na_redu(_)), assert(na_redu(X)).

% ispituje ima li dani igrac zeton na ploci. Prosljeğuje se ID igraèa.
% Najprije uèitava ID etona i pokušava naæi polje na kojem se nalazi
% eton. Polje mora biti tipa "path", "start" ili "exit".
ima_zeton_na_ploci(Igrac) :- zeton(N, Igrac), ploca(_,path,_,N);
zeton(N,Igrac), ploca(_,start,_,N);
zeton(N,Igrac), ploca(_,exit,_,N).

% odreğuje iduæeg igraèa. Prosljeğuje se ID trenutnog igraèa. Uèitava
% listu svih igraèa, poveæava ID za 1 i sprema u Iduci. Ako je Iduci
% veæi od 4, postavlja se ID na 1 i sprema u Novi, te nastavlja dalje.
% Ako Iduci nije veæi od 4, Novi samo ostaje dobiveni broj. Na taj naèin
% cirkuliraju se brojevi od 1-4.
% Zatim provjerava da li je Novi èlan uèitane liste. Ako nije, predikat
% ide u rekurziju, tj. poziva sam sebe kako bi se pokušao odrediti
% sljedeæi igraè. Ako Novi jest u listi, sprema se u globalnu varijablu
% na_redu(X).
iduci_igrac(Igrac) :- lista_igraca(Lista), Iduci is Igrac+1,
	(Iduci>4 -> Novi is 1, true; Novi is Iduci, true),
	(not(member(Novi,Lista)) -> iduci_igrac(Novi);
	retract(na_redu(_)), assert(na_redu(Novi))).

% postavlja eton s danim ID-jem (prvi arg.), od igraèa s ID-jem (drugi
% arg.) u poèetnu kuæicu. Uèitava najprije boju igraèa, nakon toga prema
% boji odreğuje na koje polje æe spremiti tj. pridruiti ID tokena.
postavi_zeton_u_kucicu(Zeton, Igrac) :- igrac(Igrac,_,Boja,_),
	retract(ploca(Zeton,shouse,Boja,_)), assert(ploca(Zeton,shouse,Boja,Zeton)).

% postavlja eton na startnu poziciju. Prvi argument - ID æetona, drugi
% argument - ID igraèa. Uèitava boju danog igraèa. Prema boji najprije
% mièe eton s postojeæeg polja te pridruuje eton novom polju.
% Jednostavnije reèeno, premješta eton s polja poèetne kuæice na
% startno polje.
postavi_zeton_na_start(Zeton, Igrac) :- igrac(Igrac,_,Boja,_),
	retract(ploca(A,shouse,Boja,Zeton)), assert(ploca(A,shouse,Boja,0)),
	retract(ploca(X,start,Boja,_)), assert(ploca(X,start,Boja,Zeton)).

% omoguæuje pomicanje igraèa. Uèitava broj na kocki te ovisno o boji
% izvršava kod. Arg: Trenutno = ID trenutnog polja, Boja = boja etona,
% Novo = izlazni arg., ID novog polja.
% Polja su definirana 1-40 (put) za
% sve boje i 41-44 (ciljna kuæica) za svaku boju posebno. Crveni poèinje
% sa polja 1, plavi s 11, zeleni s 21, a uti s 31. Potrebno je
% napraviti odreğene korekcije (npr. plavi putuje od 11-40, pa od 40-10,
% pa od 10-44). Sve boje (osim crvene koja ne mora imati korekcije),
% rade na isti naèin:
% Ako je Trenutno veæe od 10/20/30/40 [brojevi predstavljaju ID zadnjeg
% polja odreğene boje], Poc (pomoæna varijabla) se raèuna kao
% Trenutno+Broj (dobiven na kocki). Ako je Poc veæe od 40, treba ga
% korigirati, inaèe se samo sprema u Novo. (npr. za plavog: Trenutno=38,
% Broj=4, raèuna se Poc = 42, meğutim 42 je polje ciljne kucice, a plavi
% ima još komad puta za proæi, prema tome pravo Novo polje je 42-40=2.)
% Ako Trenutno nije veæe od 10, Poc je Trenutno+Broj+[30/20/10], kako
% bi se eton mogao spremiti u polje ciljne kuæice. Ako je Poc
% veæi od 44, pomak nije moguæ. Ako je Poc veæi od 40, dobivena
% vrijednost je u redu i sprema se u Novo (npr. za plavog: Trenutno=9,
% Broj=4, raèuna se Poc=13+30=43.) Ako broj nije veæi od 40, onda je
% Novo samo Trenutno+Broj (npr. za plavog: Trenutno=7, Broj=2, raèuna se
% Poc=7+2+30=39, što nije veæe od 40, znaèi da je ID pravog polja samo
% 7+2=9).
pomak(Trenutno,Boja,Novo) :-
	kocka(Broj), (Boja=='red' -> Poc is Trenutno+Broj,
		      (Poc>44 ->fail; Novo is Poc, true));
	kocka(Broj), (Boja=='blue' -> (Trenutno>10 ->
				      Poc is Trenutno+Broj,
				       (Poc>40 -> Novo is Poc-40, true;
				       Novo is Poc,true);
				      Poc is Trenutno+Broj+30,
				       (Poc>44 -> fail;
					Poc>40 -> Novo is Poc, true;
					Novo is Trenutno+Broj, true)));
	kocka(Broj), (Boja=='green' -> (Trenutno>20 ->
				       Poc is Trenutno+Broj,
					(Poc>40 -> Novo is Poc-40, true;
				       Novo is Poc,true);
				       Poc is Trenutno+Broj+20,
					(Poc>44 -> fail;
					 Poc>40 -> Novo is Poc, true;
					 Novo is Trenutno+Broj, true)));
	kocka(Broj), (Boja=='yellow' -> (Trenutno>30 ->
					Poc is Trenutno+Broj,
					 (Poc>40 -> Novo is Poc-40, true;
					  Novo is Poc,true);
					Poc is Trenutno+Broj+10,
					 (Poc>44 -> fail;
					  Poc>40 -> Novo is Poc, true;
					  Novo is Trenutno+Broj, true))).

% Argumenti: Zeton = ID etona, Boja = boja etona
% uèitava u N ID polja na kojem se nalazi zadani eton, izvršava
% predikat pomak prosljeğujuæi nağeni N i Boju te u M sprema ID polja na
% koje bi se eton trebao pomaknuti i u X sprema ID etona (ako postoji
% na ploèi, ili 0 ako ga nema). Uèitava dobiveno polje s ID-jem M (uvjet
% je da to nije 'shouse', tj. poèetna kuæica). Sprema uèitani X u
% globalnu varijablu zeton(X). Sprema uèitani M u globalnu varijablu
% novo_polje(X). Ako je X jednak 0, znaèi da je polje slobodno, u
% suprotom, vraæa se fail.
provjeri_polje(Zeton,Boja) :- ploca(N,_,_,Zeton), pomak(N,Boja,M),
	ploca(M,A,_,X), A\='shouse',
	retract(zeton(_)), assert(zeton(X)),
	retract(novo_polje(_)), assert(novo_polje(M)),
	(X==0 -> true; fail).

% Argumenti: Zeton = ID etona, Polje = ID polja na koje treba pomaknuti
% eton
% eton se briše s trenutnog polja.
% Ako je Polje veæe od 40, eton treba spremiti u ciljnu kuæicu
% ("fhouse"). U suprotnom, ga treba spremiti na bilo koje drugo polje od
% puta ploèe (dakle da nije "shouse", tj. poèetna kuæica).
pomakni_zeton(Zeton,Polje) :- retract(ploca(A,B,C,Zeton)), assert(ploca(A,B,C,0)),
	(Polje>40 -> zeton(Zeton,Igrac), igrac(Igrac,_,Boja,_),
	 retract(ploca(Polje,fhouse,Boja,_)), assert(ploca(Polje,fhouse,Boja,Zeton));
	ploca(Polje,X,_,_), X\='shouse',
	 retract(ploca(Polje,X,Y,_)), assert(ploca(Polje,X,Y,Zeton))).

% Argumenti: Zeton = ID etona, Boja = boja etona
% eton se briše s trenutnog polja i stavlja na njegovo polje u poèetnoj
% kuæici.
vrati_zeton_u_kucicu(Zeton,Boja) :-
	retract(ploca(Polje,B,C,Zeton)), assert(ploca(Polje,B,C,0)),
	retract(ploca(Zeton,shouse,Boja,_)), assert(ploca(Zeton,shouse,Boja,Zeton)).

% Arg. Polje = ID polja.
% Provjerava da li postoji neki eton na zadanom Polju. Ako ne (X=0
% znaèi da nema etona), sve je u redu, inaèe vraæa fail.
provjeri_tocno_polje(Polje) :- ploca(Polje,_,_,X), (X==0 -> true; fail).

% Arg. Boja = boja za koju se provjerava
% Uèitava se startno polje zadane bolje, u Y se sprema ID etona ili 0.
% Dobivena vrijednost iz Y se sprema u varijablu zeton(X). Ako je 0,
% polje je slobodno, u suprotnom nije pa predikat vraæa fail.
provjeri_zeton_start(Boja) :- ploca(_,start,Boja,Y),
	retract(zeton(_)), assert(zeton(Y)),(Y==0 -> true; fail).







