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

------------------------------

Reference:
http://git-scm.com/docs/git-credential-cache

#### Windows User ?
```
git config --global credential.helper wincred

```
Ref for Windows:
http://stackoverflow.com/questions/11693074/git-credential-cache-is-not-a-git-command

### Mac OS user ?
Remove keychain from storing your password (When you are on a shared computer)
```
git config --system --unset credential.helper
```
Ref:
https://stackoverflow.com/questions/16052602/disable-git-credential-osxkeychain