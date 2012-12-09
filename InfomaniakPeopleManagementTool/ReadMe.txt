Notes des changements et initatives prises par rapport aux consignes :

- Interfaces par dessus les classes pour plus de découplage et pour limiter la visibilité
- Interface + classe abstraire ? IPerson pour les champs communs professors / students
- Noms en anglais car méthodes en anglais + convention quand on code ... 
- Nom teacher -> professor (teachers are not in campus, professors are ...)
- NUnit tests ?

Choix d'implémentation :

- Campus : city, county, capacity ->read only pcq fonctionnellement cohérent + pas de risques de péter les conditions avec students existants
- Campus : can add professors, does not need to know which are of which kind. can change salaries of all internal professors + change salaries of external professors but return false if professor is internal 
	=> change that and introduce class of type internal so that only internal professors kind are accepted when changing salary method ? + better coherence with constraints 
- Student : ID read/write mais nom/prénom read-only 
- Teacher : ID read-only ? (pas spécifié donc on suppose unique et ne change pas) + nom/prénom read only
- Program : can create student, professor, campus + delete them =>should delete all entites or not ?

TODO

- How to serialize elements ? à la volée ? selon quelle organisation ? 
Comment les recharger ensuite ? dans quelle structure d'appli pour les lire et recharger le programme ?
- Ajouter les ToString() sur student/Campus/Professor etc !
- How to handle unique IDs ? comment est-ce que chaque nouvelle personne peut avoir une ID unique ?
- Implémenter comparable + tri automatique : ordered set ?
- Implémenter interface en ligne de commande : classe à part ? dans program.cs ? où mettre les actions de création ? validation des paramètres ? autre ?

Liste des contraintes et comment sont-elles respectées :

- read only students / professors : IEnumerable
- pas possible d'avoir capacité <0, salary <=0 etc : throw exception

Needed evolutions and what / how to do them :

- Unit testing with NUnit & a mock framework => TDD ?
- Internationalisation of strings & outputs
- Automatic exports ?
- UI with MVVM + ViewModel
- Bien noter que ils voulaient que ça soit fait en JAva mais justifier choix .NET pour le côté différent, certains trucs cools, + efficace dans ce language