import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
  AttributeValueServiceProxy,
  AttributeValueDto,
  AttributeValueDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateAttributeValueDialogComponent } from './create-attributevalue/create-attributevalue-dialog.component';
import { EditAttributeValueDialogComponent } from './edit-attributevalue/edit-attributevalue-dialog.component';

class PagedAttributeValuesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './attributevalues.component.html',
  animations: [appModuleAnimation()]
})
export class AttributeValuesComponent extends PagedListingComponentBase<AttributeValueDto> {
  attributevalues: AttributeValueDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _attributevalueService: AttributeValueServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedAttributeValuesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._attributevalueService
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
      .subscribe((result: AttributeValueDtoPagedResultDto) => {
        this.attributevalues = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(attributevalue: AttributeValueDto): void {
    abp.message.confirm(
      this.l('AttributeValueDeleteWarningMessage', attributevalue.valueName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._attributevalueService
            .delete(attributevalue.id)
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

  createAttributeValue(): void {
    this.showCreateOrEditAttributeValueDialog();
  }

  editAttributeValue(attributevalue: AttributeValueDto): void {
    this.showCreateOrEditAttributeValueDialog(attributevalue.id);
  }

  showCreateOrEditAttributeValueDialog(id?: number): void {
    let createOrEditAttributeValueDialog: BsModalRef;
    if (!id) {
      createOrEditAttributeValueDialog = this._modalService.show(
        CreateAttributeValueDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditAttributeValueDialog = this._modalService.show(
        EditAttributeValueDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditAttributeValueDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }
}
