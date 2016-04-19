# Описание #
Библиотека использует пространоство имен **GoogleTranslate** и содержит 2 класса:
|Название|Функция|
|:-------|:------|
|_GTranslate_|Основной статический класс, используется для перевода текста|
|_GWords_|Служит для хранения результата перевода|

и один Enum - GLanguages содержащий все доступные 42 языка.

# Класс _GTranslate_ #

## Переменные ##

Класс содержит единственную публичную переменную - **SupportLanguages** типа string[.md](.md) который содержит названия всех доступных языков.

## Функции ##

Два варианта одной функции **Translate**, служит собственно для перевода текста:
```
public static GWords Translate(GLanguages inlang, GLanguages outlang, string trtext)
public static GWords Translate(string inlang, string outlang, string trtext)
```
### Первый вариант ###

|**Параметр**|**Тип**|**Значение**|
|:-----------|:------|:-----------|
|**inlang**  |_GLanguages_|Язык с которого переводить|
|**outlang** |_GLanguages_|Язык на который переводить|
|**trtext**  |_String_|Текст для первода|

Здесь в виде языка ипользуется Enum **GLanguages**

### Второй вариант ###

|**Параметр**|**Тип**|**Значение**|
|:-----------|:------|:-----------|
|**inlang**  |_String_|Язык с которого переводить|
|**outlang** |_String_|Язык на который переводить|
|**trtext**  |_String_|Текст для первода|

Возможные варианты языков:
```
"Albanian","Arabic","Bulgarian","Catalan","Chinese (Simplified)",
"Chinese (Traditional)","Croatian","Czech","Danish","Dutch",
"English","Estonian","Filipino","Finnish","French","Galician",
"German","Greek","Hebrew","Hindi","Hungarian","Indonesian",
"Italian","Japanese","Korean","Latvian","Lithuanian",
"Maltese","Norwegian","Polish","Portuguese","Romanian",
"Russian","Serbian","Slovak","Slovenian","Spanish","Swedish"
"Thai","Turkish","Ukrainian","Vietnamese"
```

## Enums ##

Класс содержит один - единственный enum:
```
public enum GLanguages {sq ,ar , bg , ca , zhCN , zhTW  , hr , cs , da , nl , en ,
                        et , tl , fi , fr , gl , de , el , iw , hi , hu , id , it ,
                        ja , ko , lv , lt , mt , no , pl , pt , ro , ru , sr , sk ,
                        sl , es , sv , th , tr , uk , vi};
```

# Класс _GWords_ #

## Поля ##

#### Translate _(String)_ ####

Результат перевода.

### В режиме словаря ###

В режиме словаря (когда для перевода задается одно слово).

#### Noun _(StringCollection)_ ####
Варианты перевода в виде существительных.

#### Adjective _(StringCollection)_ ####
Варианты перевода в виде прилагательных.

#### Adverb _(StringCollection)_ ####
Варианты перевода в виде наречий.

#### Verb _(StringCollection)_ ####
Варианты перевода в виде глаголов.

#### Verb _(StringCollection)_ ####
Варианты перевода в виде междометий.

## Функции ##

Функция **Create** служит для обработки ответа от сервера [translate.google.com](http://translate.google.com)

```
public void Create(string source)
```

Единственый параметр функции _source_ должен содержать текст ответа от сервера.