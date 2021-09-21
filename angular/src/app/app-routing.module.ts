import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { AttributesComponent } from './attributes/attributes.component';
import { AttributeValuesComponent } from './attributevalues/attributevalues.component';
import { ProductTypesComponent } from './product-types/product-types.component';
import { ProductsComponent } from './products/products.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },

                    { path: 'products', component: ProductsComponent,  canActivate: [AppRouteGuard] },
                    { path: 'productTypes', component: ProductTypesComponent,  canActivate: [AppRouteGuard] },
                    { path: 'attributes', component: AttributesComponent,  canActivate: [AppRouteGuard] },
                    { path: 'attributeValues', component: AttributeValuesComponent,  canActivate: [AppRouteGuard] },
                    { path: 'productAttributeValues', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'productTypeAttributeValues', component: HomeComponent,  canActivate: [AppRouteGuard] },

                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    // { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
