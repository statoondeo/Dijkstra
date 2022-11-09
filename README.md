<div id="question">
<img class="main_image" src="https://questionsacm.isograd.com/codecontest/fr/ygYNuqYQe2A9u8EPeda4u.png" alt="Test">
<div class="form-group inline  " style="padding:15px 0 0 15px;margin 0">
<div class="valid-feedback"><i class="fal fa-check-circle icon-right hide"></i></div>
<div class="invalid-feedback"><i class="fal fa-times-circle icon-wrong hide"></i></div>
</div>
<div class="question_text lan_1" style="padding-top:0;"># Coût Carbone et déplacement optimal<br />
<br />
En 2021, les transports représentaient 43% des émissions de CO2 d'après l'Agence internationale de l'énergie, il est donc primordial d'optimiser ce secteur. <br />
<br />
Une bonne solution à court terme est d'utiliser les transports existants, en prenant les transports les moins émetteurs quitte à avoir plusieurs changements de transports. Il faut cependant veiller à ce que les temps de trajets ne deviennent pas rédhibitoires : pour ce dernier challenge il vous faudra trouver le chemin le moins émetteurs en CO2, mais dont la durée ne dépasse pas une durée maximale.<br />
<br />
Cherchez le déplacement optimal entre le point de départ et le point d'arrivée vérifiant une durée totale limitée et un coût carbone total minimal.<br />
<br />
## Données<br />
<br />
### Entrée<br />
<br />
**Ligne 1** : 3 entiers : `N`, `M` et `T`. `N` est  le numéro de l'étape finale. L'étape initiale est `0`, les étapes intermédiaires sont numérotées de `1` à `N-1`. `M` est la durée que doit prendre au maximum le voyage possible (la somme des durées des étapes doit être inférieure ou égale à `M`). `T` est le nombre de liaisons différentes possibles.<br />
<br />
`1＜M＜T＜=1000`<br />
<br />
**Ligne 2 à T+1** : Sur chaque ligne, une liaison possible sous la forme `i j d c` : `i` est l'étape de départ, `j` l'étape d'arrivée (on a toujours `i＜j`), `d` la durée de cette liaison et `c` le coût carbone de cette liaison.<br />
<br />
`d` et `c` sont compris entre 0 et 100.000.<br />
<br />
### Sortie<br />
<br />
Le coût carbone minimal respectant la durée en temps maximale. Répondre `-1` s'il n'existe aucun trajet possible respectant la contrainte de temps.<br />
<br />
## Exemple<br />
<br />
Pour l'entrée :<br />
```plaintext<br />
3 12 5<br />
0 1 8 1 <br />
0 2 2 8<br />
1 2 5 2 <br />
1 3 3 5<br />
2 3 1 0<br />
<br />
```<br />
<br />
La sortie est :<br />
```plaintext<br />
6<br />
```<br />
<br />
En effet le chemin à choisir est 0 - 1 - 3 d'une durée de (8+3)=11 et d'un cout carbone de (1+5)=6.<br />
Il existe bien un chemin moins couteux en carbone : 0 - 1 - 2 - 3 qui ne coûte que 3 en carbone mais sa durée totale est (8+5+1)=14 supérieure au maximum de 12 demandé.<br />
<br />
</div>
