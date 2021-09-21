import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';

// attributes
import { AttributesComponent } from '@app/attributes/attributes.component';
import { CreateAttributeDialogComponent } from './attributes/create-attribute/create-attribute-dialog.component';
import { EditAttributeDialogComponent } from './attributes/edit-attribute/edit-attribute-dialog.component';

// attributevalues
import { AttributeValuesComponent } from '@app/attributevalues/attributevalues.component';
import { CreateAttributeValueDialogComponent } from './attributevalues/create-attributevalue/create-attributevalue-dialog.component';
import { EditAttributeValueDialogComponent } from './attributevalues/edit-attributevalue/edit-attributevalue-dialog.component';

// product-types
import { ProductTypesComponent } from '@app/product-types/product-types.component';
import { CreateProductTypeDialogComponent } from './product-types/create-product-type/create-product-type-dialog.component';
import { EditProductTypeDialogComponent } from './product-types/edit-product-type/edit-product-type-dialog.component';

// products
import { ProductsComponent } from '@app/products/products.component';
import { CreateProductDialogComponent } from './products/create-product/create-product-dialog.component';
import { EditProductDialogComponent } from './products/edit-product/edit-product-dialog.component';

// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';

// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,

    // attributes
    AttributesComponent,
    CreateAttributeDialogComponent,
    EditAttributeDialogComponent,

    // attributeValues
    AttributeValuesComponent,
    CreateAttributeValueDialogComponent,
    EditAttributeValueDialogComponent,

    //product type
    ProductTypesComponent,
    CreateProductTypeDialogComponent,
    EditProductTypeDialogComponent,

    //product
    ProductsComponent,
    CreateProductDialogComponent,
    EditProductDialogComponent,

    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
  ],
  providers: [],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditAttributeDialogComponent,
    // attributes
    CreateAttributeDialogComponent,
    EditAttributeDialogComponent,
    // attributeValues
    CreateAttributeValueDialogComponent,
    EditAttributeValueDialogComponent,
    //product type
    CreateProductTypeDialogComponent,
    EditProductTypeDialogComponent,
    //product
    CreateProductDialogComponent,
    EditProductDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
  ],
})
export class AppModule {}
