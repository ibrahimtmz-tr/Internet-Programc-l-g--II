import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { ApiService } from "./api.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(
        public apiServis: ApiService,
        public router: Router
    ) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

            return true;
        }


    }


