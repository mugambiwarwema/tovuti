import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
  ProductTypeServiceProxy,
  ProductTypeDto,
  ProductTypeDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateProductTypeDialogComponent } from './create-product-type/create-product-type-dialog.component';
import { EditProductTypeDialogComponent } from './edit-product-type/edit-product-type-dialog.component';

class PagedProductTypesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './product-types.component.html',
  animations: [appModuleAnimation()]
})
export class ProductTypesComponent extends PagedListingComponentBase<ProductTypeDto> {
  productTypes: ProductTypeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _productTypeService: ProductTypeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedProductTypesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._productTypeService
      .getAll(
        request.keyword,
        0,
        // request.skipCount,
        1,
        // request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ProductTypeDtoPagedResultDto) => {
        this.productTypes = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(productType: ProductTypeDto): void {
    abp.message.confirm(
      this.l('ProductTypeDeleteWarningMessage', productType.productTypeName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._productTypeService
            .delete(productType.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createProductType(): void {
    this.showCreateOrEditProductTypeDialog();
  }

  editProductType(productType: ProductTypeDto): void {
    this.showCreateOrEditProductTypeDialog(productType.id);
  }

  showCreateOrEditProductTypeDialog(id?: number): void {
    let createOrEditProductTypeDialog: BsModalRef;
    if (!id) {
      createOrEditProductTypeDialog = this._modalService.show(
        CreateProductTypeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditProductTypeDialog = this._modalService.show(
        EditProductTypeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditProductTypeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
