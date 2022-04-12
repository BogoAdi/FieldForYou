## FieldForYou

## Prezentare generala
Aplicatia FieldForYou isi propune sa vina in ajutorul persoanelor care doresc sa inchirieze spatii pentru desfasurarea activitatilor sportive si persoanelor care detin spatiile respective.

### Cerinte functionale
Logarea se va face din 2 roluri: administrator și client.

Adminii vor putea:
-	Adauga noi terenuri de sport 
-	Aduce modificari la atributele unui teren sau chiar la eliminarea terenurilor
-	Vizualizarea unei evidențe a tuturor programarilor
-	Optional: Adminul va putea specifica unui teren anumite perioade in care nu se vor putea realiza programari.
	
Clientul va putea:
-	Realiza o programare, selectand un teren dintr-o lista  de terenuri de sport, o data , un interval orar si completand informatiile de contact
-	Sa vizualizeze un istoric al programarilor proprii
-	Acesta va avea posibilitatea de a anula o programare realizata
-	Sa caute anumite locatii dupa cuvinte cheie folosind un searchbar

De asemena atat clientul, cat si adminul vor fi notificati printr-un email cu 30 de minute inainte de o programare.

Enitatile esentiale sunt: User, SportField, Programare. Acestea vor implementa (pentru inceput) metode de get si set.



### Tehnologii alese
-	Datele vor fi persistate intr-o baza de date relationala, Microsoft SQL Server
-	Frontend-ul va fi scris in React si Material UI
-	Backend-ul va fi scris in C# si .Net
-	ORM: Entity Frameworkw Core
