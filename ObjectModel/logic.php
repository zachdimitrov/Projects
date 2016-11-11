<?php
$pref='My name is ';
$suf=', and I am ';
$end=' years old!';
$data = array();
$data['result']='';

$gosho = new User();
$gosho->setAge(19);
$gosho->setUsername('Georgi');
$data['result'].='<div>
    <b>'.$pref.$gosho->getUsername().$suf.'</b>
    <b>'.$gosho->getAge().$end.'</b>
</div>';

$pesho = new User();
$pesho->setAge(35); 
$pesho->setUsername('Petar');
$data['result'].='<div>
    <b>'.$pref.$pesho->getUsername().$suf.'</b>
    <b>'.$pesho->getAge().$end.'</b>
</div>';

$data['title'] = 'Page for users';
$data['header'] = '<h1>Page for '.$pesho->getUsername().', '.$gosho->getUsername().'</h1>';

echo '<pre>'.print_r($data, true).'</pre>';

class User {
    public $username;
    public $age;

    public function setAge($age) {
        if($age > 18 && $age < 65) {
            $this->age = $age;
        } 
    }

    public function getAge() {
        return $this->age;
    }

    public function setUsername($name) {
            $this->username = $name;
    }

    public function getUsername() {
        return $this->username;
    }


    public function normalizeName() {
        denormalizeName();
        return strtoupper($this->username);
    }

    public function denormalizeName() {

    }
}