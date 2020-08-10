#### Tired of entering password again and again ?

Run this command to remember your password:

```bash
git config --global credential.helper 'cache --timeout 28800'
```

Above command will tell git to cache your password for 8 hours.

#### How to make git forget this password ?

If you want to switch to another github account then u can run this command

```bash
git credential-cache exit
```
Above command will flush any stored password from cache.


Rename branch:
Renombra tu rama local. Si estás en la rama que quieres cambiar
$git branch -m <nuevo-nombre>

Si estás en otra rama, ejecuta el comando:
$git branch -m <nombre-antiguo> <nuevo-nombre>

Borra el nombre antiguo y haz un push del nuevo nombre de la rama local
$git push origin :<nombre-antiguo> <nuevo-nombre>

Restablezcer la rama remota desde el nuevo nombre local
git push origin -u new-name
