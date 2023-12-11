# BSU.Map.Api
Ключевые этапы для запуска сервера и клиента в локальной сети.
Сервер: 
1. Выполните клонирование репозитория на ваш ПК
2. В файле BSU.Map.WebApi\Properties\launchSettings.json измените значение поля profiles->BSU.Map.WebApi->applicationUrl на
   http://0.0.0.0:51107
3. Запустите приложение
Сеть: (К примеру домашний wi-fi)
1. Узнайте ip адрес вашего ПК в некоторой сети
2. В свойствах сети в сетевом профиле выберите опцию "частные"
3. Подключите андроид устройство к данной сети
Клиент: (необходимо предварительно скачать Android Studio)
1. Выполните клонирование репозитория по ссылке:
   https://github.com/P1l1gr1m/BSU_MAP
2. В файле KoinDataModule.kt в методе retrofitClient.retrofit() вставьте ссылку вида:
   http://ip_адрес_ПК:51107
3. Подключите андроид устройство по usb к ПК
4. В режиме разработчика разрешите установку приложений по usb
5. Запустите приложение
