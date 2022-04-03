# FieldForYou

Descriere Proiect
Acesta va avea 2 actori: administratorul și clientul.

Adminul va putea:
-	Adauga noi terenuri de sport 
-	Aduce modificari la atributele unui teren sau chiar la eliminarea terenurilor
-	Vizualizarea unei evidențe a tuturor programarilor
-	Optional: Adminul va putea specifica unui teren anumite perioade in care nu se vor putea realiza programari.
	
Clientul va putea:
-Realiza o programare, selectand un teren dintr-o lista  de terenuri de sport, o data , un interval orar si completand informatiile de contact
-Sa vizualizeze un istoric al programarilor proprii
-Acesta va avea posibilitatea de a anula o programare realizata

Enitatile esentiale sunt: User, SportField, Programare. Acestea vor implementa (pentru inceput) metode de get si set.

User-ul va avea atribute: 
-username
-password

SportField va avea:
-idField
-Category
-size
-adress
-pricePerHour

Programare va avea:
-dataProgramarii
-intervalOrar
-pretTotal
-numeClient
-numarTelefon
-DataRealizariiProgramarii
-idField.

