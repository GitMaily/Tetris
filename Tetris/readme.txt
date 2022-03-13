Quelques conseils de programmer:

1. Pour le nom d'une classe, le premier mot commence par un majuscule. Et chaques mots après commencent par majuscules.
   Pour le nom d'un méthode, la même règle.
    par exemple:
        class NomDeClass;

2. Pour un nom d'une variable, le premier mot commence par un minuscule. Et chaques mots après commencent par majuscules
    par exemple:
        Variable nomDeVariable;

3. Pour des noms de classe ou de variable, n'utilise pas abréviation.
   Utilise quelques mots exacts pour un nom d'une variable.

   exemple non recommandé:

   string strMyVariable ---- utilise l'abréviation

   exemple recommandé:
   string nomDeUser;
   int userID;

4. Utilise le commentaire de documentation:
    FR: https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/language-specification/documentation-comments
    ZH: https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/documentation-comments

    il est très utile de nous aider à comprendre ce qu'un méthode ou une classe fait sans besoin de regarder le code.

    le commentaire de documentation commence par "///"
    et il existe quelques types principals, 
    par exemple <summary> pour décrire un méthode ou une class. </summary> indique la fin du sommaire.
    <param name = "nom de paramètre"> pour expliquer un paramètre d'un méthode. </param> indique la fin.
    <returns> décrire le retour d'un méthode. </returns> indique la fin.

    le commentaire de documentation se trouve en haut d'un méthode ou d'une classe.

    un exemple d'utilise le commentaire de documentation.

    ///<summary>
    ///c'est une classe pour décrire une personne, y compris le nom, l'âge, la sexe etc.
    ///</summary>
    class Personne
    {
        
        ///<summary>
        ///Affichier l'infomation d'une personne sur l'écran.
        ///</summary>
        public void affichier()
        {
            
        }

        ///<summary>
        ///Calculer année de naissance d'une personne.
        ///</summary>
        ///<param name = "dateCourrant">
        ///Type : int \n
        ///un entier qui contient la date de cette année.
        ///</param>
        ///<returns>
        ///Type : int
        ///Retourne un entier qui contient l'année de naissance d'une personne.
        ///</returns>
        public int CalculerAnneeDeNaissance(int dateCourrant)
        {
            
        }
    }
    
    Vous pouvez copier cet exemple à votre ide pour voir l'effet du commentaire de documentation.
