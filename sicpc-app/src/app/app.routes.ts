import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { ServicesComponent } from './services/services.component';
import { LoginComponent } from './login/login.component';
import { UsuariosComponent } from './usuarios/usuarios.component';

export const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full'},

    {path: 'home', component: HomeComponent},


    {path: 'about', component: AboutComponent},

    {path: 'contact', component: ContactComponent},

    {path: 'services', component: ServicesComponent},

    {path: 'login', component: LoginComponent},

    {path: 'usuarios', component: UsuariosComponent},

    {path: '**', redirectTo: 'home'}

];
