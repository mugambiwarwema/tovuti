import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
  AttributeServiceProxy,
  AttributeDto,
  AttributeDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateAttributeDialogComponent } from './create-attribute/create-attribute-dialog.component';
import { EditAttributeDialogComponent } from './edit-attribute/edit-attribute-dialog.component';

class PagedAttributesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './attributes.component.html',
  animations: [appModuleAnimation()]
})
export class AttributesComponent extends PagedListingComponentBase<AttributeDto> {
  attributes: AttributeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _attributeService: AttributeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedAttributesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._attributeService
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
      .subscribe((result: AttributeDtoPagedResultDto) => {
        this.attributes = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(attribute: AttributeDto): void {
    abp.message.confirm(
      this.l('AttributeDeleteWarningMessage', attribute.attributeName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._attributeService
            .delete(attribute.id)
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

  createAttribute(): void {
    this.showCreateOrEditAttributeDialog();
  }

  editAttribute(attribute: AttributeDto): void {
    this.showCreateOrEditAttributeDialog(attribute.id);
  }

  showCreateOrEditAttributeDialog(id?: number): void {
    let createOrEditAttributeDialog: BsModalRef;
    if (!id) {
      createOrEditAttributeDialog = this._modalService.show(
        CreateAttributeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditAttributeDialog = this._modalService.show(
        EditAttributeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditAttributeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
