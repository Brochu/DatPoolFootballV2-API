# DatPoolFootballV2-API
Deuxieme essai pour le developpement d'un site web de pool de football

Cette fois-ci, on va essayer une methode de developpement en 2 etapes.
    - Creer un web API (C#, MongoDB, JWT) pour retourer les donnees du pool en JSON pour les differentes features
    - Creer un site web frontend qui presente les donnees de l'API dans une page web basee sur React JS

API
---------------------

Pour l'API, on veut pouvoir faire des appels en rapport avec
    - [GET] Match pour une saison / semaine donnee
    - [GET] Scores des match qui sont deja completes (probablement dans le meme appel)

    - [GET] Predictions pour une semaine donnee pour le joueur connecte
    - [GET] Predictions pour une semaine donnee pour un pool donnee du joueur
    - [POST] Predictions pour la semaine courante pour le joueur connecte
    - [PUT] Modifier les predictions pour la semaine courant pour le joueur connecte

    - [GET] Messages pour un pool donne du joueur courant (+ pagination)
    - [POST] Message pour un pool donne du joueur courant (body = message json data)
    - [DELETE] Message pour un pool donne du joueur courant (id du message a delete)

    - Les routes admins pour administrer les pools et les joueurs
