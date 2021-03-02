
1) Vad har du gjort för antaganden 
(som du inte tyckte framgick av uppgiftsbeskrivningen)?
========================================================
I uppgiften stod inte ifall speldisplayen skulle vara scrollande eller fast. Exemplet kunde ev. tolkas 
som att man skulle rita varje ny bana under den förra, men jag antog att det var OK att uppdatera 
spelplanen på plats och skriva över den förra visningen, så som riktiga spel brukar göra.


2) Något i din lösning som du vet inte fungerar enligt specifikationen?
========================================================
Nej, förtom att jag har lagt till funktioner som inte stod i specifikationen. 
Efter att jag byggt klart programmet enligt specifikationen så lade jag till extra funktionalitet, 
som möjligheten att byta syntax och utseende. Detta vore inte motiverat i en verklig utvecklingssituation, 
men eftersom denna kod är avsedd för underlag till intervjun så kände jag att det var kul att få 
visa på applikationens flexibla arkitektur och anpassningsbarhet.
Den förenklade syntaxen gjorde ocså att det gick mycket snabbare att utföra manuella tester när 
användargränssnittet togs fram.


3) Har du behövt söka efter syntax/hjälp/idéer för att lösa något i din implementation?
========================================================
Programmet och dess design är helt min egen idé, utifrån uppgiftsbeskrivningen.
Jag googlade lite om för- och nackdelar med structs, eftersom jag inte har använt dem så mycket. 
Efter att ha läst på om det beslöt jag att göra om klassen Coordinate till en struct. 
Jag googlade också upp info om diverse Console-metoder, (ConsoleColor, SetCursorPosition, ReadKey mfl.) då det var länge 
sedan jag använde dem. Jag läste också på lite om regex och stränghantering.


4) Hur utmanande tyckte du uppgiften var?
========================================================
Lagom svår. Jag har löst en del uppgifter från Advent of Code tidigare, och de erfarenheterna var till
god hjälp när jag löste denna uppgift. Problemet var enkelt nog för att jag skulle hinna med allt, och 
komplext nog för att kunna visa på lite mer avancerade programmeringstekniker, och för att motivera refaktorering.


5) Ungefär hur lång tid använde du för att lösa uppgiften (ej inräknat uppsättning av utvecklingsmiljö)?
========================================================
Planering och beslut om applikationsarkitektur skedde under spridda stunder under veckan medan jag gjorde annat, 
t.ex. tog en promenad eller lunchade. Jag uppskattar planeringstiden till mellan 2-3 timmar totalt. 
Själva programmeringen gjordes på småstunder under veckan och timrapporterades i ett Excelark. 
Efter 9 timmars programmering hade jag en fungerande, refaktorerad app med enhetstester som testade alla 
inmatningsvarianter jag kunde komma på. 
Under helgen ägnade jag sedan 4 timmar åt att designa den alternativa spelplanen, att ta fram den förenklade 
syntaxen samt att göra anpassade enhetstester till den förenklade syntaxen. 


6) Något i din lösning du är missnöjd med?
========================================================
Inte direkt. Jag hade gärna sluppit att ha så många if-satser i huvudloopen, men med tanke på alla valmöjligheter 
som finns och den felhantering som krävs så kommer jag just nu inte på något bättre sätt. Jag har i alla fall
försökt att göra koden så läsbar som möjligt.


7) Något i din lösning du är extra nöjd med?
========================================================
Främst är jag nöjd över att jag lyckade separera spellogik, användarinput, texter och grafisk presentation. Genom att
använda resultatobjekt fick jag också ett enhetligt sätt att hantera såväl kommandon som användarfeedback och felmeddelanden.
Jag är också nöjd med att kodseparationen gjorde koden så flexibel. Eftersom spelet bara är en liten konsoll-app så 
kändes det inte rätt att använda sig av ett DI-framework för dependency injection.
Jag ville ändå försöka skriva modulärt och frikopplat från beroenden. Genom att skapa upp klasser och definiera 
funktioner som sedan skickades in som metodparametrar blev lösningen ändå väldigt flexibel och lätt att testa.



8) Några andra kommentarer?
========================================================
Superkul och inspirerande uppgift som gav mig mycket!
