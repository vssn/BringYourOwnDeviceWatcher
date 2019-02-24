# BringYourOwnDeviceWatcher
WIP - Projekt ist unvollständig und erfordert zusätzliche Arbeit

## Bring-Your-Own-Device-Watcher (byod-watcher) listet deine Netzwerkgeräte auf und benachrichtigt dich, wenn ein neues Gerät im Netzwerk registriert wurde.

### Requirements
- nmap
- curl
- sed
- dotnet

### Installation
Diese Information kann sich noch maßgeblich ändern. 
- Jedenfalls brauchst du dotnet bzw. die dotnet Runtime auf deinem Server (z.B. ein Raspberry Pi)

#### Server

    dotnet run
    
#### Scanner

    ./run-the-script-from-below.sh

IP und Serveradresse im Script unten anpassen und abspeichern. Führe einen Netzwerkscan auf dein eigenes Netzwerk aus und sende die Daten zur URL der Applikation

    nmap -sn 192.168.1.* -oX ~/nmap-wlan.xml
    
    sed -i '1,4d' /path/to/nmap-wlan.xml && curl -X POST \
      https://byod-watcher/api/NmapRun \
      -H 'Content-Type: application/xml' \
      -H 'cache-control: no-cache' \ -F /path/to/nmap-wlan.xml

#### Was passiert im Script?
- Du gibst dein IP Subnetz an. Das ist der Bereich in dem die IPs der Geräte liegen, die du überwachen möchtest.
- Die Ergebnisse des Scans werden in der Datei nmap-wlan.xml abgelegt.
- Die Datei wird mit sed um die ersten 4 Zeilen gekürzt, sie enthalten den XML Header, der unbedingt zur Verarbeitung entfernt werden muss.
- Die Daten werden als XML codiert an den Server geschickt, auf dem der byod-watcher läuft.
- Optional: Crontab Eintrag für das regelmäßige Senden der Daten, z.B. 24/7 jede Stunde.

